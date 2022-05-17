using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("ProjectKnowledgeAreaLogDetails")]
	public class ProjectKnowledgeAreaLogDetails:BaseModel
    {
		[PrimaryKey]
		public string ID { get; set; }
		public string ProjectID { get; set; }
		public string ProjectKnowledgeAreaID { get; set; }
		public string BaselineValue { get; set; }
		public string BaselineValueEnteredDate { get; set; }
		public string ActualValue { get; set; }
		public string ActualVAlueEnteredDate { get; set; }
		public string ForecastValue { get; set; }
		public string ForecastValueEnteredDate { get; set; }
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
