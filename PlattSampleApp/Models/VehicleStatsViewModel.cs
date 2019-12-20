using PlattSampleApp.AppCode.Interfaces;

namespace PlattSampleApp.Models
{
	public class VehicleStatsViewModel
	{
		// AF: Added a new constructor mapping data source object with the model
		public VehicleStatsViewModel(IManufacturerSummary summary)
		{
			Map(summary);
		}

		public double AverageCost { get; set; }

		public string ManufacturerName { get; set; }

		public int VehicleCount { get; set; }

		private void Map(IManufacturerSummary summary)
		{
			AverageCost = summary.VehicleAverageCost;
			ManufacturerName = summary.ManufacturerName;
			VehicleCount = summary.VehiclesCount;
		}
	}
}