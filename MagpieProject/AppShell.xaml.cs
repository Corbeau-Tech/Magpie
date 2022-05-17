using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MagpieProject
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        public void SetCurrentToProfile()
        {
            Shell.Current.CurrentItem = profilePage;
        }
    }
}
