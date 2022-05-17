using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MagpieProject.CustomUIComponents
{
    public partial class LabelTitleValueView : ContentView
    {
        public LabelTitleValueView()
        {
            InitializeComponent();
            stackMainElement.BindingContext = this;
        }

        public static readonly BindableProperty LabelNameProperty = BindableProperty.Create(
          nameof(LabelName),
          typeof(string),
          typeof(LabelTitleValueView),
          null,
          BindingMode.OneWay);


        public string LabelName
        {
            get { return (string)GetValue(LabelNameProperty); }
            set { SetValue(LabelNameProperty, value); }
        }

        public static readonly BindableProperty LabelValueProperty = BindableProperty.Create(
          nameof(LabelValue),
          typeof(string),
          typeof(LabelTitleValueView),
          null,
          BindingMode.OneWay);


        public string LabelValue
        {
            get { return (string)GetValue(LabelValueProperty); }
            set { SetValue(LabelValueProperty, value); }
        }
    }
}
