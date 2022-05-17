using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("SettingsMaster")]
	public class SettingsMaster:BaseModel
    {
		[PrimaryKey]
		public long ID { get; set; }
		public string SettingCode { get; set; }
		public string SettingType { get; set; }
		public string SettingDescription { get; set; }
		public string DataType { get; set; }
		public string IsConditional { get; set; }
		public string IsRange { get; set; }
		public string IsNumeric { get; set; }
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
