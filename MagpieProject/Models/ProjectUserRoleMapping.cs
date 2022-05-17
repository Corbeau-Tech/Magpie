using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("ProjectUserRoleMapping")]
	public class ProjectUserRoleMapping:BaseModel
    {
		[PrimaryKey]
		public string ID { get; set; }
		public string UserID { get; set; }
		public string RoleID { get; set; }
		public string ProjectID { get; set; }
		public string ProjectCode { get; set; }
		public string RoleName { get; set; }
		public string ProjectRoleID { get; set; }
		public string ProjectRoleName { get; set; }
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
