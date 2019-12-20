using Newtonsoft.Json;
using PlattSampleApp.AppCode.Interfaces;
using System.Collections.Generic;

namespace PlattSampleApp.AppCode.Models.Swapi
{
	public class Film : IFilm
	{
		[JsonProperty("characters")]
		public IEnumerable<string> CharacterProfileUrls { get; set; }

		[JsonProperty("director")]
		public string Director { get; set; }

		[JsonProperty("episode_id")]
		public string EpisodeId { get; set; }

		[JsonProperty("opening_crawl")]
		public string OpeningCrawl { get; set; }

		[JsonProperty("planets")]
		public IEnumerable<string> PlanetProfileUrls { get; set; }

		[JsonProperty("producer")]
		public string Producer { get; set; }

		[JsonProperty("url")]
		public string ProfileUrl { get; set; }

		[JsonProperty("release_date")]
		public string ReleaseDate { get; set; }

		[JsonProperty("species")]
		public IEnumerable<string> SpecieProfileUrls { get; set; }

		[JsonProperty("starships")]
		public IEnumerable<string> StarshipProfileUrls { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("vehicles")]
		public IEnumerable<string> VehicleProfileUrls { get; set; }

		public int GetFilmId()
		{
			string[] split = ProfileUrl.Trim().Split('/');
			int length = split.Length;

			string value = split[length - 1];

			// AF: Assumption was made that last part of the URL represents ID of the movie and it may or may not be followed by /
			// Ex. https://swapi.co/api/films/1/ or https://swapi.co/api/films/1
			int id;
			if (!string.IsNullOrEmpty(value) && int.TryParse(value, out id))
				return id;
			else
				int.TryParse(split[length - 2], out id);

			return id;
		}
	}
}