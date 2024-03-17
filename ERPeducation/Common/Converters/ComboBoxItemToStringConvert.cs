using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace ERPeducation.Common.Converters
{
    public class ComboBoxItemToStringConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ComboBoxItem item) return item.Content;
            return value;
        }
    }
}
