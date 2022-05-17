using System;
using System.Collections.ObjectModel;
using MagpieProject.CustomUIComponents;
using MagpieProject.Views.ProjectsModule;
using Xamarin.Forms;

namespace MagpieProject.ViewModels.ProjectsModule
{
    public class ProjectLandingPageViewModel : BaseViewModel
    {
        public INavigation navigation { get; set; }
        private ObservableCollection<TabModel> _TabList;

        public ObservableCollection<TabModel> TabList
        {
            get { return _TabList; }
            set
            {
                _TabList = value;
                OnPropertyChanged(nameof(TabList));
            }
        }

        private int _SelectedTabIndexItem;

        public int SelectedTabIndexItem
        {
            get { return _SelectedTabIndexItem; }
            set
            {
                _SelectedTabIndexItem = value;
                OnPropertyChanged(nameof(SelectedTabIndexItem));
            }
        }

        public Command TestCommand => new Command(async () => { 
        
        });

        public Command EditTapped => new Command(async () => {
            await navigation.PushAsync(new EditProjectPage());
        });
        public ProjectLandingPageViewModel()
        {
            TabList = new ObservableCollection<TabModel>
                {
                    new TabModel()
                    {
                        TabViewControlTabItemTitle = "My Projects",
                        Page =  new MyProjectsPage(),
                        
            },
                    new TabModel()
                    {
                         TabViewControlTabItemTitle = "All Projects",
                        Page =  new AllProjectsPage(),
                    },
                  

                };
        }
    }
}
