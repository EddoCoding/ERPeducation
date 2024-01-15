using System.Globalization;
using System;
using System.Windows.Data;

namespace ERPeducation.Common.Converters
{
    public class NumberToStringEmptyConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int numberInt && numberInt == 0) return string.Empty;
            if (value is long numberLong && numberLong == 0) return string.Empty;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}
