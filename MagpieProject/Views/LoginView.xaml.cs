using System;
using System.Collections.Generic;
using MagpieProject.ViewModels;
using Xamarin.Forms;

namespace MagpieProject.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
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
                    new GradientStop { Color = (Color)App.Current.Resources["LoginPageFillGradient1"], Offset = 0.1f },
                    new GradientStop { Color = (Color)App.Current.Resources["LoginPageFillGradient2"], Offset = 0.5f },
                    new GradientStop { Color = (Color)App.Current.Resources["LoginPageFillGradient3"], Offset = 1.0f }
                }
                };
            }
            else
            {
                background = new LinearGradientBrush
                {
                    
                    GradientStops = new GradientStopCollection
                {
                    new GradientStop { Color = (Color)App.Current.Resources["LoginPageFillGradient1"], Offset = 0.1f },
                    new GradientStop { Color = (Color)App.Current.Resources["LoginPageFillGradient2"], Offset = 1.0f }
                }
                };
            }

            mainGrid.Background = background;
            #endregion SettingLinearGradient
        }
    }
}
