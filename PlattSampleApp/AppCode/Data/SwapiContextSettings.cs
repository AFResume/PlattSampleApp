using Newtonsoft.Json;

namespace PlattSampleApp.AppCode.Data
{
	public class SwapiContextSettings
	{
		[JsonProperty("films_url")]
		public string FilmsUrl { get; set; }

		[JsonProperty("planets_url")]
		public string PlanetsUrl { get; set; }

		[JsonProperty("vehicles_url")]
		public string VehiclesUrl { get; set; }
	}
}