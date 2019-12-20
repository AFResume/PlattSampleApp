using PlattSampleApp.AppCode.Interfaces;

namespace PlattSampleApp.Models
{
	public class PlanetDetailsViewModel
	{
		// AF: Added a new constructor mapping data source object with the model
		internal PlanetDetailsViewModel(IPlanet planet)
		{
			Map(planet);
		}

		// AF: Changed type from int to string because some values are returned as "unknown"
		public string Diameter { get; set; }

		public string FormattedDiameter => Diameter == "unknown" ? "unknown" : int.Parse(Diameter).ToString("N0");

		public string FormattedPopulation => Population == "unknown" ? "unknown" : long.Parse(Population).ToString("N0");

		public string LengthOfYear { get; set; }

		public string Name { get; set; }

		public string Population { get; set; }

		public string Terrain { get; set; }

		private void Map(IPlanet planet)
		{
			Diameter = planet.Diameter;
			Name = planet.Name;
			Population = planet.Population;
			Terrain = planet.Terrain;
			LengthOfYear = planet.OrbitalPeriod;
		}
	}
}