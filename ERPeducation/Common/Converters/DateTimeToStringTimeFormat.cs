using System;
using System.Globalization;
using System.Windows.Data;

namespace ERPeducation.Common.Converters
{
    public class DateTimeToStringTimeFormat : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            try
            {
                string timeFormat = parameter as string ?? "HH:mm";

                DateTime dateTime = (DateTime)value;

                return dateTime.ToString(timeFormat);
            }
            catch (Exception) { return string.Empty; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}