using System;
using System.Collections.Generic;
using MagpieProject.ViewModels.ProfileModule;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace MagpieProject.Views.ProfileModule
{
    public partial class ProfileLandingPage : ContentPage
    {
        public ProfileLandingPage()
        {
            InitializeComponent();
            BindingContext = new ProfileViewModel() { navigation = this.Navigation };
            if (Device.RuntimePlatform == Device.Android )
            {
                ScrollView sc = new ScrollView()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Content = MainGrid,
                };
                Content= sc;
            }
        }

    }
}
