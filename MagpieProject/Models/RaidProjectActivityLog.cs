using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("RaidProjectActivityLog")]
	public class RaidProjectActivityLog:BaseModel
    {
		[PrimaryKey]
		public long ID { get; set; }
		public string ProjectID { get; set; }
		public string RaidProjectID { get; set; }
		public string RaidActivityCode { get; set; }
		public string RaidActivity { get; set; }
		public DateTime ActivityDate { get; set; }
		public string Description { get; set; }
		public string OwnerUserID { get; set; }
		public string Owner { get; set; }
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
