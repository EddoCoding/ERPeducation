using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace ERPeducation.Common.Converters
{
    public class StringToDepartmentCodeConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return value;

            string inputString = value.ToString();

            inputString = inputString.Replace(" ", "");
            inputString = inputString.Replace("-", "");

            if (inputString.Length > 3)
            {
                inputString = inputString.Insert(3, "-");
                for (int i = 4; i < inputString.Length; i++) if (inputString[i] == '-') inputString = inputString.Remove(i);
            }

            return inputString;
        }
    }
}
