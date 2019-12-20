using System.Collections.Generic;

namespace PlattSampleApp.AppCode.Interfaces
{
	public interface IPlanets
	{
		string NextPage { get; set; }

		IEnumerable<IPlanet> PlanetsRecs { get; }

		void AddPlanets(IEnumerable<IPlanet> planetsToAdd);

		double GetAverageDiameter();

		IEnumerable<IPlanet> GetPlanetsSortedDescByDiameter();
	}
}