using PlattSampleApp.AppCode.Interfaces;

namespace PlattSampleApp.Models
{
	public class ResidentSummary
	{
		// AF: Added a new constructor mapping data source object with the model
		public ResidentSummary(IResident resident)
		{
			Map(resident);
		}

		public string EyeColor { get; set; }

		public string Gender { get; set; }

		public string HairColor { get; set; }

		public string Height { get; set; }

		public string Name { get; set; }

		public string SkinColor { get; set; }

		public string Weight { get; set; }

		private void Map(IResident resident)
		{
			Name = resident.Name;
			Height = resident.Height;
			Weight = resident.Weight;
			Gender = resident.Gender;
			HairColor = resident.HairColor;
			EyeColor = resident.EyeColor;
			SkinColor = resident.SkinColor;
		}
	}
}