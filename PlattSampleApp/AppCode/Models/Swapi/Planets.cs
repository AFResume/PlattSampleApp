using Newtonsoft.Json;
using PlattSampleApp.AppCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlattSampleApp.AppCode.Models.Swapi
{
	public class Planets : IPlanets
	{
		[JsonProperty("next")]
		public string NextPage { get; set; }

		public IEnumerable<IPlanet> PlanetsRecs
		{
			get
			{
				return PlanetsRecsTemp;
			}
		}

		// AF: Intermediate strongly typed property is needed during serialization to avoid exception:
		// Unable to cast object of type 'System.Collections.Generic.List`1[PlattSampleApp.AppCode.Models.Swapi.Planet]' to type 'System.Collections.Generic.IEnumerable`1[PlattSampleApp.AppCode.Interfaces.IPlanet]'
		[JsonProperty("results")]
		private List<Planet> PlanetsRecsTemp { get; set; } = new List<Planet>();

		// AF: We cannot add to IEnumerable type property directly, so this serves as a setter for strongly typed intermediate property
		public void AddPlanets(IEnumerable<IPlanet> planetsToAdd)
		{
			foreach (IPlanet p in planetsToAdd)
				PlanetsRecsTemp.Add((Planet)p);
		}

		public double GetAverageDiameter()
		{
			if (PlanetsRecs == null)
				return 0;
			else
				// AF: I assumed that values can only be "unknown" or a number
				return PlanetsRecs
					.Where(d => !string.Equals(d.Diameter, "unknown", StringComparison.OrdinalIgnoreCase))
					.Average(d => double.Parse(d.Diameter));
		}

		public IEnumerable<IPlanet> GetPlanetsSortedDescByDiameter()
		{
			if (PlanetsRecs?.Any() == null)
				return PlanetsRecs;

			return PlanetsRecs.Where(d => !string.Equals(d.Diameter, "unknown", StringComparison.OrdinalIgnoreCase))
				.OrderByDescending(d => int.Parse(d.Diameter))
				.Concat(PlanetsRecs.Where(d => string.Equals(d.Diameter, "unknown", StringComparison.OrdinalIgnoreCase))).ToList();
		}
	}
}