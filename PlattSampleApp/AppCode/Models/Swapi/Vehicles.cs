using Newtonsoft.Json;
using PlattSampleApp.AppCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlattSampleApp.AppCode.Models.Swapi
{
	/// AF: IMPORTANT! Some vehicles are made by multiple manufacturers, but I treat them as one manufacturer, otherwise it would significantly
	/// complicate the solution and also I am not sure whether the average cost could be accurately calculated in that case.
	public class Vehicles : IVehicles
	{
		[JsonProperty("next")]
		public string NextPage { get; set; }

		public IEnumerable<IVehicle> VehicleRecs
		{
			get
			{
				return VehicleRecsTemp;
			}
		}

		// AF: Intermediate strongly typed property is needed during serialization to avoid exception:
		// Unable to cast object of type 'System.Collections.Generic.List`1[PlattSampleApp.AppCode.Models.Swapi.Planet]' to type 'System.Collections.Generic.IEnumerable`1[PlattSampleApp.AppCode.Interfaces.IPlanet]'
		[JsonProperty("results")]
		private List<Vehicle> VehicleRecsTemp { get; set; } = new List<Vehicle>();

		// AF: We cannot add to IEnumerable type property directly, so this serves as a setter for strongly typed intermediate property
		public void AddVehicles(IEnumerable<IVehicle> vehiclesToAdd)
		{
			foreach (IVehicle v in vehiclesToAdd)
				VehicleRecsTemp.Add((Vehicle)v);
		}

		public IEnumerable<IManufacturerSummary> GetManufacturerSummaries()
		{
			// AF: Limiting results only to vehicles with known cost AND manufacturer(s)
			List<Vehicle> vehicles = VehicleRecsTemp.Where(x => !x.Cost.Equals("unknown", StringComparison.OrdinalIgnoreCase) && !x.Manufacturer.Equals("unknown", StringComparison.OrdinalIgnoreCase)).ToList();

			List<ManufacturerSummary> summaries = new List<ManufacturerSummary>();
			vehicles.Select(m => m.Manufacturer)
				.Distinct(StringComparer.OrdinalIgnoreCase).ToList()
				.ForEach(r => summaries.Add(new ManufacturerSummary() { ManufacturerName = r }));

			foreach (ManufacturerSummary summary in summaries)
			{
				List<Vehicle> vehicleByMfg = vehicles.Where(m => m.Manufacturer.Equals(summary.ManufacturerName, StringComparison.OrdinalIgnoreCase)).ToList();
				summary.VehiclesCount = vehicleByMfg.Count();

				// AF: Assuming all values being valid as double, otherwise need to use TryParse and make code more complex
				summary.VehicleAverageCost = vehicleByMfg.Average(c => double.Parse(c.Cost));
			}

			return summaries.OrderByDescending(o => o.VehiclesCount).ThenByDescending(o => o.VehicleAverageCost);
		}

		public int GetUniqueManufacturersCount()
		{
			// AF: Result from API contains "Incom Corporation" and "Incom corporation", I treat them as the same manufacturer.
			// Also result from API contains an "uknown" manufacturer and I ignore it during calculation.
			return VehicleRecs.Select(m => m.Manufacturer)
				.Where(m => !m.Equals("unknown", StringComparison.OrdinalIgnoreCase))
				.Distinct(StringComparer.CurrentCultureIgnoreCase).Count();
		}

		public int GetVehiclesCount(bool includeUnknownCost)
		{
			if (includeUnknownCost)
				return VehicleRecs.Count();
			else
				return VehicleRecs.Count(x => !x.Cost.Equals("unknown", StringComparison.OrdinalIgnoreCase));
		}
	}
}