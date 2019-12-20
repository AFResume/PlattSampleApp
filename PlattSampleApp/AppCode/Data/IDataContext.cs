using PlattSampleApp.AppCode.Interfaces;
using System.Collections.Generic;

namespace PlattSampleApp.AppCode.Data
{
	public interface IDataContext
	{
		IPlanets GetAllPlanets();

		IVehicles GetAllVehicles();

		IPlanet GetPlanetById(int id);

		IEnumerable<IResident> GetPlanetResidents(string planetName);

		IEnumerable<IFilm> GetFilms();

		IFilm GetFilmByEpisodeId(int id);
	}
}