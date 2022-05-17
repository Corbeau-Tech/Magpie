using System;
using System.Collections.Generic;
using MagpieProject.ViewModels.ProjectsModule;
using Xamarin.Forms;

namespace MagpieProject.Views.ProjectsModule
{
    public partial class MyProjectsPage : ContentView
    {
        public MyProjectsPage()
        {
            InitializeComponent();
            BindingContext = new MyProjectsViewModel() { navigation=this.Navigation};
        }
        
    }
}
