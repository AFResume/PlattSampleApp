using Newtonsoft.Json;
using PlattSampleApp.AppCode.Interfaces;
using System.Collections.Generic;

namespace PlattSampleApp.AppCode.Models.Swapi
{
	public class Planet : IPlanet
	{
		[JsonProperty("climate")]
		public string Climate { get; set; }

		[JsonProperty("created")]
		public string CreatedOn { get; set; }

		[JsonProperty("diameter")]
		public string Diameter { get; set; }

		[JsonProperty("edited")]
		public string EditedOn { get; set; }

		[JsonProperty("films")]
		public IEnumerable<string> FilmsProfileUrls { get; set; }

		[JsonProperty("gravity")]
		public string Gravity { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("orbital_period")]
		public string OrbitalPeriod { get; set; }

		[JsonProperty("population")]
		public string Population { get; set; }

		[JsonProperty("residents")]
		public IEnumerable<string> ResidentProfileUrls { get; set; }

		[JsonProperty("rotation_period")]
		public string RotationPeriod { get; set; }

		[JsonProperty("surface_water")]
		public string SurfaceWater { get; set; }

		[JsonProperty("terrain")]
		public string Terrain { get; set; }

		[JsonProperty("url")]
		public string ProfileUrl { get; set; }
	}
}