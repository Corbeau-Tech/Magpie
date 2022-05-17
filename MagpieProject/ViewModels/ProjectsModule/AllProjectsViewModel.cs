using System;
using System.Collections.ObjectModel;
using MagpieProject.Database;
using MagpieProject.Models;
using MagpieProject.Views.ProjectsModule;
using Xamarin.Forms;

namespace MagpieProject.ViewModels.ProjectsModule
{
    public class AllProjectsViewModel : BaseViewModel
    {
        public INavigation navigation { get; set; }
        private ObservableCollection<ProjectModel> _AllProjectsList;

        public ObservableCollection<ProjectModel> AllProjectsList
        {
            get { return _AllProjectsList; }
            set
            {
                _AllProjectsList = value;
                OnPropertyChanged(nameof(AllProjectsList));
            }
        }
        public Command ProjectTapped => new Command(async (model) =>
        {
            var projectmodel = model as ProjectModel;
            if (projectmodel != null)
            {
                await navigation.PushAsync(new ProjectDetailPage(projectmodel));
            }
        });

        public AllProjectsViewModel()
        {
            AllProjectsList = new ObservableCollection<ProjectModel>(DBManager.Instance().GetRecords<ProjectModel>());
            
        }
    }
}
