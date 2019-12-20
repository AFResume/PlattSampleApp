using PlattSampleApp.AppCode.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PlattSampleApp.Models
{
	public class VehicleSummaryViewModel
	{
		// AF: Added input parameter to map data source object with model's property
		public VehicleSummaryViewModel(IVehicles vehicles)
		{
			Details = new List<VehicleStatsViewModel>();

			ManufacturerCount = vehicles.GetUniqueManufacturersCount();
			VehicleCount = vehicles.GetVehiclesCount(false);

			var summaries = vehicles.GetManufacturerSummaries().ToList();
			summaries.ForEach(r => Details.Add(new VehicleStatsViewModel(r)));
		}

		public List<VehicleStatsViewModel> Details { get; set; }

		public int ManufacturerCount { get; set; }

		public int VehicleCount { get; set; }
	}
}