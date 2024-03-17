using System;
using System.Globalization;
using System.Windows.Data;

namespace ERPeducation.Common.Converters
{
    public class DateTimeToStringFormatConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime && dateTime == DateTime.MinValue) return string.Empty;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try { return DateTime.ParseExact((string)value, "dd.MM.yyyy", CultureInfo.InvariantCulture); }
            catch { return DateTime.MinValue; }
        }
    }
}
