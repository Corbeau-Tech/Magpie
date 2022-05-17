using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("OrganizationMaster")]
	public class OrganizationMaster:BaseModel
    {
		[PrimaryKey]
		public long ID { get; set; }
		public string OrganizationCode { get; set; }
		public string Name { get; set; }
		public string Logo { get; set; }
		public string FullName { get; set; }
		public string ShortDescription { get; set; }
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
