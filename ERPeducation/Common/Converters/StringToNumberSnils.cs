using System.Globalization;
using System.Windows.Data;
using System;

namespace ERPeducation.Common.Converters
{
    public class StringToNumberSnils : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return value;

            string inputString = value.ToString();

            inputString = inputString.Replace(" ", "");
            inputString = inputString.Replace("-", "");

            if (inputString.Length > 3) inputString = inputString.Insert(3, "-");
            if (inputString.Length > 7) inputString = inputString.Insert(7, "-");
            if (inputString.Length > 11) inputString = inputString.Insert(11, " ");

            return inputString;
        }
    }
}
