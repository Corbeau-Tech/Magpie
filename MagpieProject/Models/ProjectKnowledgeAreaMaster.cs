using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("ProjectKnowledgeAreaMaster")]
	public class ProjectKnowledgeAreaMaster:BaseModel
    {
		[PrimaryKey]
		public string ID { get; set; }
		public string KnowledgeAreaName { get; set; }
		public string KnowledgeAreaCode { get; set; }
		public string KnowledgeAreaInitial { get; set; }
		public string Description { get; set; }
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
