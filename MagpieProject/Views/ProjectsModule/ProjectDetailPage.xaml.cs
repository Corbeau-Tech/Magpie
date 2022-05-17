using System;
using System.Collections.Generic;
using System.Linq;
using MagpieProject.Components;
using MagpieProject.Database;
using MagpieProject.Models;
using MagpieProject.ViewModels.ProjectsModule;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;

namespace MagpieProject.Views.ProjectsModule
{
    public partial class ProjectDetailPage : ContentPage
    {
        ProjectDetailsViewModel vm;
        public ProjectDetailPage(ProjectModel project)
        {
            
            BindingContext = vm=new ProjectDetailsViewModel(project);
            InitializeComponent();
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (vm != null)
            {
                vm.navigation = this.Navigation;
            }
            #region SettingLinearGradient
            LinearGradientBrush background;
            if (App.IsDark)
            {
                background = new LinearGradientBrush
                {

                    GradientStops = new GradientStopCollection
                {
                    new GradientStop { Color = (Color)App.Current.Resources["ProjectsLandingPageBackground1"], Offset = 0.1f },
                    new GradientStop { Color = (Color)App.Current.Resources["ProjectsLandingPageBackground2"], Offset = 0.5f },
                    new GradientStop { Color = (Color)App.Current.Resources["ProjectsLandingPageBackground3"], Offset = 1.0f }
                }
                };
            }
            else
            {
                background = new LinearGradientBrush
                {

                    GradientStops = new GradientStopCollection
                {
                    new GradientStop { Color = Color.White, Offset = 0.1f },
                    new GradientStop { Color =Color.White, Offset = 1.0f }
                }
                };
            }

            mainGrid.Background = background;
            #endregion SettingLinearGradient
        }
        


        async void SwipeView_SwipeStarted(System.Object sender, Xamarin.Forms.SwipeStartedEventArgs e)
        {
            var currentProject = vm.ProjectSelected;
            var allfavprojects = DBManager.Instance().GetUserFavProjects();
            int newindex = 0;
            int currentprojectindex = allfavprojects.IndexOf(allfavprojects.Where(x=>x.ID==currentProject.ID).FirstOrDefault());
            if (e.SwipeDirection == SwipeDirection.Right)
            {
                //show prev project
               
                if (allfavprojects!=null && allfavprojects.Count > 0)
                {
                    
                    if (currentprojectindex == 0)
                    {
                        swipeview.Close();
                        return;
                        
                    }
                    else
                    {
                        newindex = currentprojectindex - 1;
                        var currentpage = App.Current.MainPage;

                        await App.Current.MainPage.Navigation.PushAsync(new ProjectDetailPage(allfavprojects[newindex]),false);
                        App.Current.MainPage.Navigation.RemovePage(this);
                    }
                }
                

            }
            else if (e.SwipeDirection == SwipeDirection.Left)
            {
                //show next project
                if (allfavprojects != null && allfavprojects.Count > 0)
                {

                    if (currentprojectindex == allfavprojects.Count-1)
                    {
                        swipeview.Close();
                        return;
                    }
                    else
                    {
                        newindex = currentprojectindex + 1;
                        var currentpage = App.Current.MainPage;
                        
                        await App.Current.MainPage.Navigation.PushAsync(new ProjectDetailPage(allfavprojects[newindex]),false);
                        App.Current.MainPage.Navigation.RemovePage(this);
                    }
                }
            }
        }
    }
}
