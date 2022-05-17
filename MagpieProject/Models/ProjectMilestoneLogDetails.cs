using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("ProjectMilestoneLogDetails")]
	public class ProjectMilestoneLogDetails:BaseModel
    {
		[PrimaryKey]
		public long ID { get; set; }
		public string ProjectID { get; set; }
		public string MilestoneStatusID { get; set; }
		public string MilestoneCode { get; set; }
		public string MilestoneStatus { get; set; }
		public string Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string PercentComplete { get; set; }
		public string Owner { get; set; }
		public string Predecessor { get; set; }
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
