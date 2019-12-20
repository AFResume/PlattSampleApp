using Newtonsoft.Json;
using PlattSampleApp.AppCode.Interfaces;

namespace PlattSampleApp.AppCode.Models.Swapi
{
	public class Resident : IResident
	{
		[JsonProperty("eye_color")]
		public string EyeColor { get; set; }

		[JsonProperty("gender")]
		public string Gender { get; set; }

		[JsonProperty("hair_color")]
		public string HairColor { get; set; }

		[JsonProperty("height")]
		public string Height { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("skin_color")]
		public string SkinColor { get; set; }

		[JsonProperty("mass")]
		public string Weight { get; set; }
	}
}