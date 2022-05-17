using System;
using SQLite;

namespace MagpieProject.Models.UserSettings
{
    [Table("UserSetting")]
    public class UserLoginDetails:BaseModel
    {
        [PrimaryKey]
        public string userId { get; set; }

        public string email { get; set; }
        public bool isprofileimagepresent { get; set; }
        public string fullname { get; set; }
        public string password { get; set; }
    }
}
