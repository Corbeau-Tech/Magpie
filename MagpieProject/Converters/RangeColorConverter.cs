using System;
using System.Globalization;
using Xamarin.Forms;

namespace MagpieProject.Converters
{
    public class RangeColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rangeval = 0;
            if (!string.IsNullOrWhiteSpace(value?.ToString()))
            {
                int.TryParse(value.ToString(), out rangeval);
                if (rangeval > 80)
                {
                    return Color.FromHex("#5AC53A");
                }
                else if (rangeval>=60 && rangeval <= 80)
                {
                    return Color.FromHex("#EDD86D");
                }
                else if (rangeval < 60)
                {
                    return Color.FromHex("#ED6D6D");
                }
              
                   
            }
            return Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
