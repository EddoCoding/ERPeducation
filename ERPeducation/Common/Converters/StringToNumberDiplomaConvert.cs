using System;
using System.Globalization;
using System.Windows.Data;

namespace ERPeducation.Common.Converters
{
    public class StringToNumberDiplomaConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return value;

            string inputString = value.ToString();

            inputString = inputString.Replace(" ", "");

            if (inputString.Length > 6) inputString = inputString.Insert(6, " ");

            return inputString;
        }
    }
}
