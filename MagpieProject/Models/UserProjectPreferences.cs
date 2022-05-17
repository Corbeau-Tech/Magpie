using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("UserProjectPreferences")]
	public class UserProjectMapping : BaseModel
    {
		[PrimaryKey]
		public string ID { get; set; }
		public string UserID { get; set; }
		public string ProjectID { get; set; }
		public bool IsFavorite { get; set; }
		public int Sequence { get; set; }
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
