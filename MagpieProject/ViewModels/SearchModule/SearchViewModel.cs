using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MagpieProject.Database;
using MagpieProject.Models;
using MagpieProject.Models.UserSettings;
using MagpieProject.ViewModels.ProjectsModule;
using Xamarin.Forms;

namespace MagpieProject.ViewModels.SearchModule
{
    public class SearchViewModel : BaseViewModel
    {
        private ObservableCollection<ProjectModel> _ProjectsList;

        public ObservableCollection<ProjectModel> ProjectsList
        {
            get { return _ProjectsList; }
            set
            {
                _ProjectsList = value;
                OnPropertyChanged();
            }
        }
        private List<ProjectModel> _FavoriteList;

        public List<ProjectModel> FavoriteList
        {
            get { return _FavoriteList; }
            set
            {
                _FavoriteList = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<ProjectModel> _BackupProjectsList;

        public ObservableCollection<ProjectModel> BackupProjectsList
        {
            get { return _BackupProjectsList; }
            set
            {
                _BackupProjectsList = value;
                OnPropertyChanged();
            }
        }

        private string _SearchText;

        public string SearchText
        {
            get { return _SearchText; }
            set
            {
                _SearchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }
        public Command FavoriteCommand => new Command(async (model) =>
        {
            var selectedmodel = (ProjectModel)model;
            if (selectedmodel.IsSelected)
                return;


            UserProjectMapping userprojectmappingrecord = new UserProjectMapping()
            {
                ID = Guid.NewGuid().ToString(),
                UserID = App.UserID,
                ProjectID = selectedmodel.ID,
                Sequence = BackupProjectsList.Where(x => x.IsSelected).Count() + 1
            };
            bool result =DBManager.Instance().InsertData(userprojectmappingrecord);
            if (result)
            {
                selectedmodel.IsSelected = true;
                BackupProjectsList.Where(x => x.ID == selectedmodel.ID).FirstOrDefault().IsSelected = true;
                MessagingCenter.Send(this, "RefreshProjects");
            }
        }
       );
        public Command SearchCommand => new Command(async () =>
        {
            if (String.IsNullOrEmpty(SearchText))
            {
                ProjectsList = new ObservableCollection<ProjectModel>();
            }
            else
            {

                ProjectsList = new ObservableCollection<ProjectModel>(
                    BackupProjectsList.Where(x =>
               x.ProjectName.ToLower().Contains(SearchText.ToLower()) ||
               x.Description.ToLower().Contains(SearchText.ToLower())).ToList())
                ;
            }
        });
        public SearchViewModel()
        {
            refreshlist();
            MessagingCenter.Unsubscribe<MyProjectsViewModel>(this, "RefreshSearch");
            MessagingCenter.Subscribe<MyProjectsViewModel>(this, "RefreshSearch", refreshlist);

        }
        public void refreshlist(object y = null)
        {
            BackupProjectsList = new ObservableCollection<ProjectModel>(
                 DBManager.Instance().GetRecords<ProjectModel>());
            FavoriteList = DBManager.Instance().GetUserFavProjects();
            if (FavoriteList != null && FavoriteList.Count > 0)
            {
                foreach (var item in FavoriteList)
                {
                    BackupProjectsList.Where(x => x.ID == item.ID).FirstOrDefault().IsSelected = true;

                }
            }
            ProjectsList = new ObservableCollection<ProjectModel>();
        }
    }
}
