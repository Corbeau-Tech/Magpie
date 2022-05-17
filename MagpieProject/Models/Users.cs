using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace MagpieProject.Models
{
	[Table("Users")]
	public class Users :BaseModel
    {
		[PrimaryKey]
		public string ID { get; set; }
		public string UserID { get; set; }
		public string Role { get; set; }
		public string RoleID { get; set; }
		public string UserType { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get; set; }
		public string Initials { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public DateTime DOJ { get; set; }
		public DateTime DOB { get; set; }
		public string AlternatePhoneNumber { get; set; }
		public string BUID { get; set; }
		public string TimeZone { get; set; }
		public string ProfilePhoto { get; set; }
		public string SelectedTheme { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public string version { get; set; }
		public string Remarks { get; set; }

		private bool _IsEditSelected;
		[Ignore]
		public bool IsEditSelected
		{
			get
			{
				return _IsEditSelected;
			}
			set
			{
				_IsEditSelected = value;
				OnPropertyChanged(nameof(IsEditSelected));
			}
		}
		private Color _RandomColor;
		[Ignore]
		public Color RandomColor
		{
			get
			{
				Random r = new Random();
				int indexofcolor = r.Next(0, colors.Count);
				_RandomColor = colors[indexofcolor];
				return _RandomColor;
			}
			set
			{
				Random r = new Random();
				int indexofcolor = r.Next(0, colors.Count);
				_RandomColor = colors[indexofcolor];
				OnPropertyChanged(nameof(RandomColor));
			}
		}

		List<Color> colors = new List<Color>()
		{
			Color.FromHex("#18A0FB"),
			Color.FromHex("#6E56F4"),
			Color.FromHex("#E8637B"),
			Color.FromHex("#7D89FC"),
			Color.FromHex("#B43BEF")

		};

	}
}
