using System;
using SQLite;

namespace MagpieProject.Models
{
   [Table("ItemModel")]
	public class ItemModel
	{
		public string DESCRIPTION { get; set; }
		public string ITEMTYPE { get; set; }
		public string STATUS { get; set; }

		
	}
}
