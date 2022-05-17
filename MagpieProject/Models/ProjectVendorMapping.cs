using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("ProjectVendorMapping")]
	public class ProjectVendorMapping:BaseModel
    {
		[PrimaryKey]
		public long ID { get; set; }
		public string ProjectID { get; set; }
		public string VendorID { get; set; }
		public DateTime ContractStartDate { get; set; }
		public DateTime ContracEndDate { get; set; }
		public bool IsOnetime { get; set; }
		public bool IsAutoRenewal { get; set; }
		public string TotalBudget { get; set; }
		public string ActualSpent { get; set; }
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
