using System;
using System.Collections.Generic;
using MagpieProject.ViewModels.ProfileModule;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace MagpieProject.Views.ProfileModule
{
    public partial class PickImagePopUP : PopupPage
    {
        public PickImagePopUP(ProfileViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

    }
}
