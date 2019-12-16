using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PrototypeUI_2.Converter
{
    public class BoolToVisibilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;

            if ((bool)value == bool.Parse(parameter.ToString()))
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
