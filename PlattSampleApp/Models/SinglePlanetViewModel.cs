using PlattSampleApp.AppCode.Interfaces;

namespace PlattSampleApp.Models
{
	public class SinglePlanetViewModel
	{
		// AF: Added a new constructor mapping data source object with the model
		internal SinglePlanetViewModel(int planetId, IPlanet planet)
		{
			Map(planetId, planet);
		}

		public string Climate { get; set; }

		public string Diameter { get; set; }

		public string Gravity { get; set; }

		public string LengthOfDay { get; set; }

		public string LengthOfYear { get; set; }

		public string Name { get; set; }

		public int PlanetId { get; set; }

		public string Population { get; set; }

		public string SurfaceWaterPercentage { get; set; }

		private void Map(int planetId, IPlanet planet)
		{
			Climate = planet.Climate;
			Diameter = planet.Diameter;
			Gravity = planet.Gravity;
			LengthOfDay = planet.RotationPeriod;
			LengthOfYear = planet.OrbitalPeriod;
			Name = planet.Name;
			PlanetId = planetId;
			SurfaceWaterPercentage = planet.SurfaceWater;

			long population;
			Population = long.TryParse(planet.Population, out population) ? population.ToString("N0") : planet.Population;
		}
	}
}