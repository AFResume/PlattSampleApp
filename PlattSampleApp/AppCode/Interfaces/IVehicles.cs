using System.Collections.Generic;

namespace PlattSampleApp.AppCode.Interfaces
{
	public interface IVehicles
	{
		string NextPage { get; set; }

		IEnumerable<IVehicle> VehicleRecs { get; }

		IEnumerable<IManufacturerSummary> GetManufacturerSummaries();

		int GetUniqueManufacturersCount();

		int GetVehiclesCount(bool includeUnknownCost);
	}
}