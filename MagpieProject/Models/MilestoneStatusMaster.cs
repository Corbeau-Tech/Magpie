using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("MilestoneStatusMaster")]
	public class MilestoneStatusMaster:BaseModel
    {
		[PrimaryKey]
		public long ID { get; set; }
		public string MilestoneStatus { get; set; }
		public string MilestoneCode { get; set; }
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
