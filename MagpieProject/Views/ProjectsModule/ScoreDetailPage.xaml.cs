using System;
using System.Collections.Generic;
using MagpieProject.Models;
using MagpieProject.ViewModels.ProjectsModule;
using Xamarin.Forms;

namespace MagpieProject.Views.ProjectsModule
{
    public partial class ScoreDetailPage : ContentPage
    {
        public ScoreDetailPage(ProjectKnowledgeAreaMaster masterdata,ProjectKnowledgeAreaLogDetails logdetails, Users projectlead
            ,ProjectModel currentproject)
        {
            InitializeComponent();
            BindingContext = new ScoreDetailViewModel(masterdata,logdetails,projectlead, currentproject);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            #region SettingLinearGradient
            LinearGradientBrush background;
            if (App.IsDark)
            {
                background = new LinearGradientBrush
                {

                    GradientStops = new GradientStopCollection
                {
                    new GradientStop { Color = (Color)App.Current.Resources["ProjectsLandingPageBackground1"], Offset = 0.1f },
                    new GradientStop { Color = (Color)App.Current.Resources["ProjectsLandingPageBackground2"], Offset = 0.5f },
                    new GradientStop { Color = (Color)App.Current.Resources["ProjectsLandingPageBackground3"], Offset = 1.0f }
                }
                };
            }
            else
            {
                background = new LinearGradientBrush
                {

                    GradientStops = new GradientStopCollection
                {
                    new GradientStop { Color = Color.White, Offset = 0.1f },
                    new GradientStop { Color =Color.White, Offset = 1.0f }
                }
                };
            }

            mainGrid.Background = background;
            #endregion SettingLinearGradient
        }
    }
}
