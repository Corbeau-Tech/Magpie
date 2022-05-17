using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MagpieProject.Helper;
using MagpieProject.ViewModels.ProjectsModule;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace MagpieProject.CustomUIComponents
{
    public partial class SummaryChart : ContentView, INotifyPropertyChanged
    {
        private bool _IsPercentageSelected;

        public bool IsPercentageSelected
        {
            get { return _IsPercentageSelected; }
            set
            {
                _IsPercentageSelected = value;

                OnPropertyChanged();
            }
        }
        public SummaryChart()
        {
            try
            {

                InitializeComponent();
                percentagecurrencyRow.BindingContext = this;
                IsPercentageSelected = true;
                PercentageChart.IsVisible = true;
                CurrencyChart.IsVisible = false;
            }
            catch (Exception ex)
            {

            }
           
        }

        #region INotifyPropertyChanged

        public new event PropertyChangedEventHandler PropertyChanged;

        protected new void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
        void percentagetile_tapped(System.Object sender, System.EventArgs e)
        {
            IsPercentageSelected = true;
            PercentageChart.IsVisible = true;
            CurrencyChart.IsVisible = false;
        }

        void currencytile_Tapped(System.Object sender, System.EventArgs e)
        {
            IsPercentageSelected = false;
            PercentageChart.IsVisible = false ;
            CurrencyChart.IsVisible = true;
        }

        void onemonth_tapped(System.Object sender, System.EventArgs e)
        {
            Frame frame = sender as Frame;
            if (frame.BindingContext.GetType() == typeof(ProjectDetailsViewModel))
            {
                var model = frame.BindingContext as ProjectDetailsViewModel;
                model.Is1MSelected = true;
                model.Is3MSelected = false;
                model.Is6MSelected = false;
                model.Is1YSelected = false;
            }
            
        }

        void threemonth_tapped(System.Object sender, System.EventArgs e)
        {
            Frame frame = sender as Frame;
            if (frame.BindingContext.GetType() == typeof(ProjectDetailsViewModel))
            {
                var model = frame.BindingContext as ProjectDetailsViewModel;
                model.Is1MSelected = false ;
                model.Is3MSelected = true;
                model.Is6MSelected = false;
                model.Is1YSelected = false;
            }
        }

        void sixmonth_tapped(System.Object sender, System.EventArgs e)
        {
            Frame frame = sender as Frame;
            if (frame.BindingContext.GetType() == typeof(ProjectDetailsViewModel))
            {
                var model = frame.BindingContext as ProjectDetailsViewModel;
                model.Is1MSelected = false;
                model.Is3MSelected = false;
                model.Is6MSelected = true;
                model.Is1YSelected = false;
            }
        }

        void oneyear_tapped(System.Object sender, System.EventArgs e)
        {
            Frame frame = sender as Frame;
            if (frame.BindingContext.GetType() == typeof(ProjectDetailsViewModel))
            {
                var model = frame.BindingContext as ProjectDetailsViewModel;
                model.Is1MSelected = false;
                model.Is3MSelected = false;
                model.Is6MSelected = false;
                model.Is1YSelected = true;
            }
        }

        void currencyaxis_LabelCreated(System.Object sender, Syncfusion.SfChart.XForms.ChartAxisLabelEventArgs e)
        {
            double labelContent = Convert.ToDouble(e.LabelContent);
            e.LabelContent = "$"+NumberExtension.FormatNumber(labelContent);
        }
    }

}
