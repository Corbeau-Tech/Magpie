using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MagpieProject.Components
{
    public partial class GaugeComponent : ContentView
    {
        public static readonly BindableProperty MarkerValueProperty = BindableProperty.Create(
        nameof(MarkerValue),
        typeof(string),
        typeof(GaugeComponent),
        null,
        BindingMode.TwoWay,propertyChanged: IsMarkerValueChanged);

        private static void IsMarkerValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            GaugeComponent control = (GaugeComponent)bindable;
            control.MarkerValue = newValue as string;
        }

        public string MarkerValue
        {
            get { return (string)GetValue(MarkerValueProperty); }
            set { SetValue(MarkerValueProperty, value); }
        }
        public GaugeComponent()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
