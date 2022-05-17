using System;
using System.Collections.Generic;
using MagpieProject.ViewModels.ProjectsModule;
using MagpieProject.ViewModels.SearchModule;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MagpieProject.Views.ProjectsModule
{
    public partial class ProjectLandingPage : ContentPage
    {
        private ProjectLandingPageViewModel viewmodel;
        public ProjectLandingPage()
        {
            InitializeComponent();
            BindingContext = viewmodel=new ProjectLandingPageViewModel();
            viewmodel.navigation = this.Navigation;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Device.RuntimePlatform == Device.Android)
            {
                BindingContext = new ProjectLandingPageViewModel();
            }
            #region SettingLinearGradient
            LinearGradientBrush background;
            if (App.IsDark) {
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
            //var safeInsets = On<iOS>().SafeAreaInsets();
            //safeInsets.Bottom = 80;
            //Padding = safeInsets;
        }

    }
}
