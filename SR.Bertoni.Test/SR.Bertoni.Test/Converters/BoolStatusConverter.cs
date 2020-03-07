using System;
using System.Globalization;
using Xamarin.Forms;

namespace SR.Bertoni.Test.Converters
{
    public class BoolStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
            {
                throw new InvalidOperationException("The target must be a boolean");
            }

            return (bool)value ? "Completed" : "Incomplete";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}