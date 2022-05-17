using System;
using System.Collections.Generic;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace MagpieProject.CustomUIComponents
{
    public partial class HealthProjectGraph : ContentView
    {
        public static readonly BindableProperty AnnotationValueProperty = BindableProperty.Create(
         nameof(AnnotationValue),
         typeof(string),
         typeof(HealthProjectGraph),
         null,
         BindingMode.OneWay,null, propertyChanged: IsAnnotationChanged);

        private static void IsAnnotationChanged(BindableObject bindable, object oldValue, object newValue)
        {
            HealthProjectGraph control = (HealthProjectGraph)bindable;
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
        public HealthProjectGraph()
        {
            InitializeComponent();
            
        }
    }
}
