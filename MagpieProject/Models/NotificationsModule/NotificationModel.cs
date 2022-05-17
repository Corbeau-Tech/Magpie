using System;
using SQLite;

namespace MagpieProject.Models.NotificationsModule
{
    [Table("Notifications")]
    public class NotificationModel:BaseModel
    {
        [PrimaryKey]
        public string ID { get; set; }
        private bool _IsDismissed;

        public bool IsDismissed
        {
            get
            {
                return _IsDismissed;
            }
            set
            {
                _IsDismissed = value;
                OnPropertyChanged();
            }
        }

        public string NotificationDate { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationDescription { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
