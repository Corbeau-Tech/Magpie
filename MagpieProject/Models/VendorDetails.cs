using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("VendorDetails")]
	public class VendorDetails:BaseModel
    {
		[PrimaryKey]
		public long ID { get; set; }
		public string VendorID { get; set; }
		public string ContactName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string VendorAddress { get; set; }
		public string AlternateNumber { get; set; }
		public bool IsPrimary { get; set; }
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
