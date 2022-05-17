using System;
using System.Collections.Generic;
using MagpieProject.ViewModels.NotificationsModule;
using Xamarin.Forms;

namespace MagpieProject.Views.NotificationsModule
{
    public partial class NotificationPage : ContentPage
    {
        public NotificationPage()
        {
            InitializeComponent();
            BindingContext = new NotificationViewModel();
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
                notificationpage.Background = background;
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
                notificationpage.Background = new LinearGradientBrush() { GradientStops = new GradientStopCollection() { new GradientStop() { Color = Color.White, Offset = 0.1f }, new GradientStop() { Color = Color.White, Offset = 1.0f } } };
                mainStack.Background = background;
            }

            
            #endregion SettingLinearGradient
        }
    }
}
