using System;
using System.Globalization;
using Xamarin.Forms;

namespace MagpieProject.Converters
{
    public class RagStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rangeval = 0;
            if (!string.IsNullOrWhiteSpace(value?.ToString()))
            {
                int.TryParse(value.ToString(), out rangeval);
                if (rangeval > 80)
                {
                    return ImageSource.FromFile("upgreen.png");
                }
                else if (rangeval >= 60 && rangeval <= 80)
                {
                    return ImageSource.FromFile("neautral.png");
                }
                else if (rangeval < 60)
                {
                    return ImageSource.FromFile("downred.png");
                }
            }
            return ImageSource.FromFile("neautral.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
