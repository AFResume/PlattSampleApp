using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlattSampleApp.AppCode.Interfaces;
using PlattSampleApp.AppCode.Models.Swapi;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace PlattSampleApp.AppCode.Data
{
	// TODO: Add a handler of System.Net.WebException: 'The remote server returned an error: (404) Not Found.'
	public class SwapiContext : IDataContext
	{
		private readonly SwapiContextSettings settings;

		public SwapiContext()
		{
			settings = LoadSettings();
		}

		public IPlanets GetAllPlanets()
		{
			string url = settings.PlanetsUrl;
			Planets result = new Planets();

			// API returns 10 records per result and each result contains property "next" with URL to the next page to retrieve,
			// but last result returns "null" instead of URL, so check for that.
			while (!string.IsNullOrEmpty(url))
			{
				Planets pageResult = GetApiObject<Planets>(url);
				result.AddPlanets(pageResult.PlanetsRecs);
				url = pageResult.NextPage;
			}

			return result;
		}

		public IVehicles GetAllVehicles()
		{
			string url = settings.VehiclesUrl;
			Vehicles result = new Vehicles();

			while (!string.IsNullOrEmpty(url))
			{
				Vehicles pageResult = GetApiObject<Vehicles>(url);
				result.AddVehicles(pageResult.VehicleRecs);
				url = pageResult.NextPage;
			}

			return result;
		}

		public IFilm GetFilmByEpisodeId(int id)
		{
			return GetApiObject<Film>($"{settings.FilmsUrl}/{id}");
		}

		public IEnumerable<IFilm> GetFilms()
		{
			string content = GetApiResource(settings.FilmsUrl);

			JObject jObject = JObject.Parse(content);
			List<JToken> results = jObject["results"].Children().ToList();
			List<Film> films = new List<Film>();
			results.ForEach(r => films.Add(r.ToObject<Film>()));

			return films;
		}

		public IPlanet GetPlanetById(int id)
		{
			return GetApiObject<Planet>($"{settings.PlanetsUrl}/{id}");
		}

		public IEnumerable<IResident> GetPlanetResidents(string planetName)
		{
			Planet planet = GetPlanetByName(planetName);

			if (planet == null)
				return null;

			List<Resident> residents = new List<Resident>();

			foreach (string residentProfileUrl in planet.ResidentProfileUrls)
			{
				string content = GetApiResource(residentProfileUrl);
				Resident resident = JsonConvert.DeserializeObject<Resident>(content);
				residents.Add(resident);
			}

			return residents;
		}

		private T GetApiObject<T>(string url)
		{
			string content = GetApiResource(url);
			return JsonConvert.DeserializeObject<T>(content);
		}

		private string GetApiResource(string url)
		{
			string content = string.Empty;

			try
			{
				using (WebClient wc = new WebClient())
				{
					content = wc.DownloadString(url);
				}
			}
			catch
			{
				// AF: To keep code simple I am not doing any error logging here,
				// but if this was a real life application, this would have been required.

				throw;
			}

			return content;
		}

		private Planet GetPlanetByName(string name)
		{
			string url = settings.PlanetsUrl;

			while (!string.IsNullOrEmpty(url))
			{
				Planets pageResult = GetApiObject<Planets>(url);
				Planet planet = (Planet)pageResult.PlanetsRecs.SingleOrDefault(n => n.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));

				if (planet != null)
					return planet;

				url = pageResult.NextPage;
			}

			return null;
		}

		private SwapiContextSettings LoadSettings()
		{
			string content = File.ReadAllText(HttpContext.Current.Server.MapPath("~/AppCode/Data/SwapiContextSettings.json"));
			return JsonConvert.DeserializeObject<SwapiContextSettings>(content);
		}
	}
}