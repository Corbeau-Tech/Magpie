using System;
using System.Globalization;
using Xamarin.Forms;

namespace MagpieProject.Converters
{
    public class StatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string status = "";
            if (!string.IsNullOrWhiteSpace(value?.ToString()))
            {
                status = value.ToString().ToLower();
                if (status=="in progress" || status=="completed")
                {
                    return Color.FromHex("#5AC53A");
                }
                else if (status == "at risk" || status == "blocked")
                {
                    return Color.FromHex("#ED6D6D");
                }
                else if (status == "not started" || status == "on hold")
                {
                    return Color.FromHex("#EDD86D");
                }
            }
            return Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}