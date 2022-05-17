using System;
using SQLite;

namespace MagpieProject.Models
{
	[Table("CurrencyConverterDetails")]
	public class CurrencyConverterDetails:BaseModel
    {
		[PrimaryKey]
		public long ID { get; set; }
		public string FromCurrencyCode { get; set; }
		public string FromCurrencyID { get; set; }
		public string ToCurrencyCode { get; set; }
		public string ToCurrencyID { get; set; }
		public decimal ConversionRate { get; set; }
		public DateTime FiscalPeriod { get; set; }
		public DateTime ValidFrom { get; set; }
		public DateTime ValidTo { get; set; }
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
