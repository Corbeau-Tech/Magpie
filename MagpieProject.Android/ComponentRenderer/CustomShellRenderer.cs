using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using AndroidX.AppCompat.Widget;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Tabs;
using MagpieProject;
using MagpieProject.Droid.ComponentRenderer;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(AppShell), typeof(CustomShellRenderer))]
namespace MagpieProject.Droid.ComponentRenderer
{
    public class CustomShellRenderer : ShellRenderer
    {
        public CustomShellRenderer(Context context) : base(context)
        {

        }

        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {
            return new MyTabLayoutAppearanceTracker(this,shellItem);
        }

    }

    public class MyTabLayoutAppearanceTracker : ShellBottomNavViewAppearanceTracker
    {
        public MyTabLayoutAppearanceTracker(IShellContext shellContext, ShellItem shellItem)
            : base(shellContext, shellItem)
        {
            
        }

        public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            base.SetAppearance(bottomView, appearance);
            //if (Application.Current.Resources.TryGetValue("TabBarBackgroundColor", out var retVal)) {

            //}
         
            ////bottomView.BackgroundTintMode = PorterDuff.Mode.Lighten;
            //bottomView.SetBackgroundColor(((Xamarin.Forms.Color)retVal).ToAndroid());
           
        }



    
    }

    //    public override void SetAppearance(TabLayout tabLayout, ShellAppearance appearance)
    //    {
    //        base.SetAppearance(tabLayout, appearance);
    //        Android.Graphics.Color tabBarColor = ((Xamarin.Forms.Color)Xamarin.Forms.Application.Current.Resources["TabBarBackgroundColor"]).ToAndroid();

    //        tabLayout.SetTab(tabBarColor);
    //    }
    //}
}
