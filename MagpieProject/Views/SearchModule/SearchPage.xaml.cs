using System;
using System.Collections.Generic;
using MagpieProject.ViewModels.ProjectsModule;
using MagpieProject.ViewModels.SearchModule;
using Xamarin.Forms;

namespace MagpieProject.Views.SearchModule
{
    public partial class SearchPage : ContentPage
    {
        private SearchViewModel viewmodel;
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = viewmodel= new SearchViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
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
                    new GradientStop { Color = (Color)App.Current.Resources["ProjectsLandingPageBackground1"], Offset = 0.1f },
                    new GradientStop { Color = (Color)App.Current.Resources["ProjectsLandingPageBackground2"], Offset = 1.0f }
                }
                };
            }

            mainStack.Background = background;

            #endregion SettingLinearGradient
            var vm = (SearchViewModel)BindingContext;
            vm.SearchText = "";
            vm.ProjectsList = new System.Collections.ObjectModel.ObservableCollection<Models.ProjectModel>();
        }


        void Search_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            viewmodel.SearchCommand.Execute(null);
        }

    }
}
