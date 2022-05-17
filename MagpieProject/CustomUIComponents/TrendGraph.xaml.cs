using System;
using System.Collections.Generic;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace MagpieProject.CustomUIComponents
{
    public partial class TrendGraph : ContentView
    {
        public static readonly BindableProperty AnnotationValueProperty = BindableProperty.Create(
         nameof(AnnotationValue),
         typeof(string),
         typeof(TrendGraph),
         null,
         BindingMode.OneWay, null, propertyChanged: IsAnnotationChanged);

        private static void IsAnnotationChanged(BindableObject bindable, object oldValue, object newValue)
        {
            TrendGraph control = (TrendGraph)bindable;
            DateTime date = DateTime.Now;
            EllipseAnnotation annotation = new EllipseAnnotation()
            {
                X1 = date,

                Y1 = Convert.ToDouble(newValue),

                Height = 30,

                Width = 30,
                Text = newValue.ToString(),
                FillColor = Color.FromHex("#5AC53A"),
                StrokeColor = Color.White,

            };

            annotation.LabelStyle.TextColor = Color.White;
            control.HealthProjectionChart.ChartAnnotations.Add(annotation);
        }

        public string AnnotationValue
        {
            get { return (string)GetValue(AnnotationValueProperty); }
            set { SetValue(AnnotationValueProperty, value); }
        }
        public TrendGraph()
        {
            InitializeComponent();

        }
    }
}
