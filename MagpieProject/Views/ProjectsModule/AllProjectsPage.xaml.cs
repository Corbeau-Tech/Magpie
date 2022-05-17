using System;
using System.Collections.Generic;
using MagpieProject.ViewModels.ProjectsModule;
using Xamarin.Forms;

namespace MagpieProject.Views.ProjectsModule
{
    public partial class AllProjectsPage : ContentView
    {
        public AllProjectsPage()
        {
            InitializeComponent();
            BindingContext = new AllProjectsViewModel() { navigation = this.Navigation };
        }
    }
}
