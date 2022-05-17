using System;
using SQLite;

namespace MagpieProject.Models
{
    [Table("ContractModel")]
	public class ContractModel
	{
		public string DESCRIPTION { get; set; }
		public string TYPE { get; set; }
		public string STATUS { get; set; }
		public string MASTERCONTRACTNUM { get; set; }
		public string STARTDATE { get; set; }
		public string ENDDATE { get; set; }
		public string RENEWALDATE { get; set; }

	}
}
