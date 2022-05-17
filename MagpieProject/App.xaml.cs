using System;
using System.Collections.Generic;
using MagpieProject.Database;
using MagpieProject.Styles;
using MagpieProject.Themes;
using MagpieProject.Views;
using MagpieProject.Views.ProfileModule;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MagpieProject
{
    public partial class App : Application
    {

        const int smallWightResolution = 1242;
        const int smallHeightResolution =2208;
        public App()
        {
            InitializeComponent();
           
            AppTheme appTheme = AppInfo.RequestedTheme;
            ICollection<ResourceDictionary> mergedDictionaries = Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();
                if (appTheme == AppTheme.Light || appTheme == AppTheme.Unspecified )
                {
                    IsLight = true;
                    IsDark = false;
                    mergedDictionaries.Add(new LightTheme());
                }
                else
                {
                    IsDark = true;
                    IsLight = false;
                    mergedDictionaries.Add(new DarkTheme());
                }
                
            }
            LoadStyles();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTYxNDAzQDMxMzkyZTM0MmUzMEI2Unlva0xEMnB5K2FLcVp4QkQzTzhEc0gzU01pSFFuRGc3b1FUQlkwNWM9");

            //MainPage = new AppShell();
            if (DBManager.Instance().CheckForLoggedInUser())
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new NavigationPage(new LoginView());
            }
            //MainPage = new NavigationPage(new TestComponentPage());
        }

        public void LoadStyles()
        {
            if (IsASmallDevice())
            {
                dictionary.MergedDictionaries.Add(SmallDevicesStyle.SharedInstance);
            }
            else
            {
                dictionary.MergedDictionaries.Add(GeneralDevicesStyle.SharedInstance);
            }
        }

        public static bool IsASmallDevice()
        {
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            return (width <= smallWightResolution && height <= smallHeightResolution);
        }

        public static bool IsFirstTime { get; set; }
        public static string UserID { get; set; }
        public static bool IsDark { get; set; }
        public static bool IsLight { get; set; }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
