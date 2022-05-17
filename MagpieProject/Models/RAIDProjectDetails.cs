using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("RAIDProjectDetails")]
	public class RAIDProjectDetails:BaseModel
    {
		[PrimaryKey]
		public long ID { get; set; }
		public string ProjectID { get; set; }
		public string Description { get; set; }
		public string RaidTypeID { get; set; }
		public string RaidStatusID { get; set; }
		public string Probability { get; set; }
		public string Impact { get; set; }
		public string Criticality { get; set; }
		public DateTime TriggerDate { get; set; }
		public string TriggerStatus { get; set; }
		public DateTime LastActivityDate { get; set; }
		public string IDLE { get; set; }
		public string AGE { get; set; }
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
