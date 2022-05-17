using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MagpieProject.Components;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;

namespace MagpieProject.Views
{
    public partial class TestComponentPage : ContentPage,INotifyPropertyChanged
    {
        

        private float PercentageProperty;

        public float Percentage
        {
            get { return PercentageProperty; }
            set
            {
                PercentageProperty = value;
                OnPropertyChanged();
            }
        }

        List<ChartEntry> entries = new List<ChartEntry>
        {
            new ChartEntry(200)
            {
                Color=SKColor.Parse("#FF1943"),
                Label ="January",
                ValueLabel = "200"
            },
            new ChartEntry(400)
            {
                Color = SKColor.Parse("00BFFF"),
                Label = "March",
                ValueLabel = "400"
            },
            new ChartEntry(-100)
            {
                Color =  SKColor.Parse("#00CED1"),
                Label = "Octobar",
                ValueLabel = "-100"
            },
            };
        public TestComponentPage()
        {
            InitializeComponent();
            Percentage = 0;
            BindingContext = this;
            //Chart1.Chart = new GuageControl("35") { Entries = entries };
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
