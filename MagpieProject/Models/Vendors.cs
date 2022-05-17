using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("Vendors")]
	public class Vendors:BaseModel
    {
		[PrimaryKey]
		public long ID { get; set; }
		public string VendorName { get; set; }
		public string VendorDomainID { get; set; }
		public string VendorTypeID { get; set; }
		public string VendorCategoryID { get; set; }
		public string VendorCode { get; set; }
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
