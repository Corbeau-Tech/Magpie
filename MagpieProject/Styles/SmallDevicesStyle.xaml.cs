using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MagpieProject.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SmallDevicesStyle : ResourceDictionary
    {
        public static SmallDevicesStyle SharedInstance { get; } = new SmallDevicesStyle();

        public SmallDevicesStyle()
        {
            InitializeComponent();
        }
    }
}
