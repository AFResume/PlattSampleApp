using Newtonsoft.Json;
using PlattSampleApp.AppCode.Interfaces;

namespace PlattSampleApp.AppCode.Models.Swapi
{
	public class Vehicle : IVehicle
	{
		[JsonProperty("cost_in_credits")]
		public string Cost { get; set; }

		[JsonProperty("manufacturer")]
		public string Manufacturer { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}