using PlattSampleApp.AppCode.Interfaces;

namespace PlattSampleApp.AppCode.Models.Swapi
{
	public class ManufacturerSummary : IManufacturerSummary
	{
		public string ManufacturerName { get; set; }

		public double VehicleAverageCost { get; set; }

		public int VehiclesCount { get; set; }
	}
}