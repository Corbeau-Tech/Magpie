using System;
using System.Globalization;
using Xamarin.Forms;

namespace MagpieProject.Converters
{
    public class ProjectHealthRangeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float rangeval = 0;
            if (!string.IsNullOrWhiteSpace(value?.ToString()))
            {
                float.TryParse(value.ToString(), out rangeval);
                if (rangeval > .9f)
                {
                    return Color.FromHex("#5AC53A");
                }
                else if (rangeval > .8f && rangeval <= .9f)
                {
                    return Color.FromHex("#AADD69");
                }
                else if (rangeval > .6f && rangeval <= .8f)
                {
                    return Color.FromHex("#EDD86D");
                }
                else if (rangeval < .6f)
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
