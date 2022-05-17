using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace MagpieProject.CustomUIComponents
{
    public partial class DetailHeaderWithoutUserGroup : ContentView
    {
        public static readonly BindableProperty TitleNameProperty = BindableProperty.Create(
         nameof(TitleName),
         typeof(string),
         typeof(DetailHeaderWithoutUserGroup),
         null,
         BindingMode.OneWay);


        public string TitleName
        {
            get { return (string)GetValue(TitleNameProperty); }
            set { SetValue(TitleNameProperty, value); }
        }

        public static readonly BindableProperty IsEditVisibleProperty = BindableProperty.Create(
         nameof(IsEditVisible),
         typeof(bool),
         typeof(DetailHeaderWithoutUserGroup),
         null,
         BindingMode.OneWay);


        public bool IsEditVisible
        {
            get { return (bool)GetValue(IsEditVisibleProperty); }
            set { SetValue(IsEditVisibleProperty, value); }
        }

        public static readonly BindableProperty EditCommandProperty =
    BindableProperty.Create(nameof(EditCommand), typeof(ICommand), typeof(DetailHeaderWithoutUserGroup), null);

        public ICommand EditCommand
        {
            get { return (ICommand)GetValue(EditCommandProperty); }
            set { SetValue(EditCommandProperty, value); }
        }

        public DetailHeaderWithoutUserGroup()
        {
            InitializeComponent();
            BindingContext = this;
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
            if (EditCommand != null && EditCommand.CanExecute(null))
            {
                EditCommand.Execute(null);
            }
        }
    }
}
