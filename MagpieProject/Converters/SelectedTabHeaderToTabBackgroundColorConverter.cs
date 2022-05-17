using System;
using System.Globalization;
using MagpieProject.CustomUIComponents;
using Xamarin.Forms;

namespace MagpieProject.Converters
{
    internal class SelectedTabHeaderToTabBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isCurrentTabSelected = false;
            if (!string.IsNullOrWhiteSpace(value?.ToString()))
                bool.TryParse(value.ToString(), out isCurrentTabSelected);

            return parameter is TabViewControl tvc && isCurrentTabSelected ? tvc.HeaderSelectionUnderlineColor : (object)Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
