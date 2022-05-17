using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MagpieProject.Database;
using MagpieProject.Models.NotificationsModule;
using Xamarin.Forms;

namespace MagpieProject.ViewModels.NotificationsModule
{
    public class NotificationViewModel : BaseViewModel
    {

        private ObservableCollection<NotificationModel> _NotificationsList;

        public ObservableCollection<NotificationModel> NotificationsList
        {
            get { return _NotificationsList; }
            set
            {
                _NotificationsList = value;

                OnPropertyChanged();
            }
        }

        public Command ReviewCommand => new Command(async (model) =>
        {
          
        }
        );

        public Command DismissCommand => new Command(async (model) =>
        {
            int result = DBManager.Instance().DeleteRecord<NotificationModel>(((NotificationModel)model)?.ID);
            if (result == 1)
            {
                NotificationsList.Remove((NotificationModel)model);
            }
           
        }
       );


        public NotificationViewModel()
        {
            List<NotificationModel> data = DBManager.Instance().GetRecords<NotificationModel>();
            NotificationsList = new ObservableCollection<NotificationModel>((data?.OrderByDescending(x=>x.CreatedDate)));
            
        }
    }
}
