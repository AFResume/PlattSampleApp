using System.Collections.Generic;

namespace PlattSampleApp.AppCode.Interfaces
{
	public interface IPlanet
	{
		string Climate { get; set; }

		string CreatedOn { get; set; }

		string Diameter { get; set; }

		string EditedOn { get; set; }

		IEnumerable<string> FilmsProfileUrls { get; set; }

		string Gravity { get; set; }

		string Name { get; set; }

		string OrbitalPeriod { get; set; }

		string Population { get; set; }

		IEnumerable<string> ResidentProfileUrls { get; set; }

		string RotationPeriod { get; set; }

		string SurfaceWater { get; set; }

		string Terrain { get; set; }

		string ProfileUrl { get; set; }
	}
}