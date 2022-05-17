using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MagpieProject.Models;
using Xamarin.Forms;

namespace MagpieProject.CustomUIComponents
{
    public partial class DetailHeader : ContentView
    {
        public static readonly BindableProperty ProjectNameProperty = BindableProperty.Create(
          nameof(ProjectName),
          typeof(string),
          typeof(DetailHeader),
          null,
          BindingMode.OneWay);


        public string ProjectName
        {
            get { return (string)GetValue(ProjectNameProperty); }
            set { SetValue(ProjectNameProperty, value); }
        }
        public static readonly BindableProperty ProjectDescriptionProperty = BindableProperty.Create(
          nameof(ProjectDescription),
          typeof(string),
          typeof(DetailHeader),
          null,
          BindingMode.OneWay);


        public string ProjectDescription
        {
            get { return (string)GetValue(ProjectDescriptionProperty); }
            set { SetValue(ProjectDescriptionProperty, value); }
        }

        public static readonly BindableProperty PeopleProperty = BindableProperty.Create(
         nameof(People),
         typeof(ObservableCollection<Person>),
         typeof(DetailHeader),
         null,
         BindingMode.OneWay);


        public ObservableCollection<Person> People
        {
            get { return (ObservableCollection<Person>)GetValue(PeopleProperty); }
            set { SetValue(PeopleProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
    BindableProperty.Create(nameof(Command),typeof(ICommand),typeof(DetailHeader),null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public DetailHeader()
        {
            InitializeComponent();
            mainGrid.BindingContext = this;
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
                    new GradientStop { Color = (Color)App.Current.Resources["ProjectsLandingPageBackground1"], Offset = 0.1f },
                    new GradientStop { Color = (Color)App.Current.Resources["ProjectsLandingPageBackground2"], Offset = 1.0f }
                }
                };
            }

            mainGrid.Background = background;
            #endregion SettingLinearGradient
        }

        async void Back_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            if (Command != null && Command.CanExecute(null))
            {
                Command.Execute(null);
            }
        }
    }
}
