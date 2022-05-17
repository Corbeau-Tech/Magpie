using System;
using System.Globalization;
using Xamarin.Forms;

namespace MagpieProject.Converters
{
    internal class SelectedTabHederTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return System.Convert.ToBoolean(value)
                    ? (Color)Application.Current.Resources["PrimayActionColor"]
                    : (object)(Color)Application.Current.Resources["PrimaryFontColor"];
            }
            return Color.Blue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
