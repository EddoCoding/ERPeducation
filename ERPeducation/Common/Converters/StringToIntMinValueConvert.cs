using System;
using System.Globalization;
using System.Windows.Data;

namespace ERPeducation.Common.Converters
{
    public class StringToIntMinValueConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (int.TryParse((string)value, out int resultInt)) return resultInt;
            if (long.TryParse((string)value, out long resultLong)) return resultLong;
            if (value is string) return string.Empty;
            return value;
        }
    }
}
