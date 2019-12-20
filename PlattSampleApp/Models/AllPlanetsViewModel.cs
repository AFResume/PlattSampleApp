using PlattSampleApp.AppCode.Interfaces;
using System.Collections.Generic;

namespace PlattSampleApp.Models
{
	public class AllPlanetsViewModel
	{
		// AF: Added input parameter to map data source object with model's property
		public AllPlanetsViewModel(IPlanets planets)
		{
			Planets = Convert(planets.GetPlanetsSortedDescByDiameter());
			AverageDiameter = planets.GetAverageDiameter();
		}

		public double AverageDiameter { get; set; }

		public List<PlanetDetailsViewModel> Planets { get; set; }

		// AF: Added
		private List<PlanetDetailsViewModel> Convert(IEnumerable<IPlanet> planets)
		{
			List<PlanetDetailsViewModel> result = new List<PlanetDetailsViewModel>();

			foreach (IPlanet p in planets)
				result.Add(new PlanetDetailsViewModel(p));

			return result;
		}
	}
}