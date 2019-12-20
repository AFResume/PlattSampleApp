namespace PlattSampleApp.AppCode.Interfaces
{
	public interface IManufacturerSummary
	{
		string ManufacturerName { get; set; }

		double VehicleAverageCost { get; set; }

		int VehiclesCount { get; set; }
	}
}