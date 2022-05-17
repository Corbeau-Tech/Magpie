using System;
using MagpieProject.iOS.ComponentRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(BorderlessEntryRenderer))]
namespace MagpieProject.iOS.ComponentRenderer
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            try
            {

                base.OnElementChanged(e);
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;
            }
            catch (Exception ex)
            {

            }

        }
    }
}
