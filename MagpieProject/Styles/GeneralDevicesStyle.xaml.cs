using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MagpieProject.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneralDevicesStyle : ResourceDictionary
    {
        public static GeneralDevicesStyle SharedInstance { get; } = new GeneralDevicesStyle();

        public GeneralDevicesStyle()
        {
            InitializeComponent();
        }
    }
}
