using PlattSampleApp.AppCode.Interfaces;
using System.Collections.Generic;

namespace PlattSampleApp.Models
{
	public class PlanetResidentsViewModel
	{
		// AF: Added input parameter to map data source object with model's property
		public PlanetResidentsViewModel(string planetName, IEnumerable<IResident> residents)
		{
			PlanetName = planetName;
			Residents = Convert(residents);
		}

		public string PlanetName { get; set; }

		public List<ResidentSummary> Residents { get; set; }

		private List<ResidentSummary> Convert(IEnumerable<IResident> residents)
		{
			List<ResidentSummary> result = new List<ResidentSummary>();

			foreach (var resident in residents)
				result.Add(new ResidentSummary(resident));

			return result;
		}
	}
}