using System;
using System.Globalization;
using System.Windows.Data;

namespace ERPeducation.Common.Converters
{
    public class StringToIntFormatConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return value;

            string inputString = value.ToString();

            inputString = inputString.Replace(" ", "");

            if (inputString.Length > 2) inputString = inputString.Insert(2, " ");
            if (inputString.Length > 5) inputString = inputString.Insert(5, " ");

            return inputString;
        }
    }
}
