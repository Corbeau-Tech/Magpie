using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("ProjectSliceDetails")]
	public class ProjectSliceDetails:BaseModel
    {
		[PrimaryKey]
		public long ID { get; set; }
		public string ProjectID { get; set; }
		public string SliceNo { get; set; }
		public string SliceDate { get; set; }
		public string PercentageComplete { get; set; }
		public string ActualWork { get; set; }
		public string BaselineWork { get; set; }
		public string ForecastWork { get; set; }
		public string Cost { get; set; }
		public string Duration { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string PV { get; set; }
		public string EV { get; set; }
		public string SV { get; set; }
		public string CV { get; set; }
		public string AC { get; set; }
		public string SPI { get; set; }
		public string CPI { get; set; }
		public string EAC { get; set; }
		public bool Tier1Visible { get; set; }
		public DateTime Tier1VisibleFromDate { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public string version { get; set; }
		public string Remarks { get; set; }
	}
}
