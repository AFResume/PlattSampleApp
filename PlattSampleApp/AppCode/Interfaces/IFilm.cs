using System.Collections.Generic;

namespace PlattSampleApp.AppCode.Interfaces
{
	public interface IFilm
	{
		IEnumerable<string> CharacterProfileUrls { get; set; }

		string Director { get; set; }

		string EpisodeId { get; set; }

		string OpeningCrawl { get; set; }

		IEnumerable<string> PlanetProfileUrls { get; set; }

		string Producer { get; set; }

		string ProfileUrl { get; set; }

		string ReleaseDate { get; set; }

		IEnumerable<string> SpecieProfileUrls { get; set; }

		IEnumerable<string> StarshipProfileUrls { get; set; }

		string Title { get; set; }

		IEnumerable<string> VehicleProfileUrls { get; set; }

		int GetFilmId();
	}
}