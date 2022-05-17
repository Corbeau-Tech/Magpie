using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("BusinessUnitMaster")]
    public class BusinessUnitMaster:BaseModel
    {
		[PrimaryKey]
		public long ID { get; set; }
		public string BUCode { get; set; }
		public string ORGID { get; set; }
		public string Description { get; set; }
		public string BUName { get; set; }
		public string BUDetails { get; set; }
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
