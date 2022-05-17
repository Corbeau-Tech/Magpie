using System;
using System.ComponentModel;
using CoreGraphics;
using MagpieProject.iOS.ComponentRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Shell), typeof(CustomShellRenderer))]
namespace MagpieProject.iOS.ComponentRenderer
{
    public class CustomShellRenderer : ShellRenderer
    {
        protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
        {
            var renderer = base.CreateShellSectionRenderer(shellSection);
            if (renderer != null)
            {
                var a = (renderer as ShellSectionRenderer);
                (renderer as ShellSectionRenderer).NavigationBar.Translucent = false;
            }
            return renderer;
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item)
        {
            var renderer = base.CreateShellItemRenderer(item);
            if (Xamarin.Forms.Application.Current.Resources.TryGetValue("TabBarBackgroundColor", out var retVal))
            {

            }
            UIColor tabBarColor = ((Xamarin.Forms.Color)retVal).ToUIColor();

            //(renderer as ShellItemRenderer).TabBar.Translucent = false;
            (renderer as ShellItemRenderer).TabBar.BackgroundColor = tabBarColor;
            //(renderer as ShellItemRenderer).TabBar.ItemWidth=50;
            //(renderer as ShellItemRenderer).TabBar.LayoutMargins=new UIEdgeInsets(0,20,0,0);
            (renderer as ShellItemRenderer).TabBar.ItemPositioning = UITabBarItemPositioning.Fill;
            return renderer;
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

    }
}
