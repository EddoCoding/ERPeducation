using ERPeducation.Views.AdmissionCampaign.DocumentsView;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace ERPeducation.Common.Converters
{
    public class UserControlToStringConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is UserControl[] userControls)
            {
                List<string> comboBoxItems = new List<string>();

                foreach (UserControl userControl in userControls)
                {
                    switch (userControl)
                    {
                        case PassportView passportView:
                            comboBoxItems.Add("Паспорт");
                            break;
                        case SnilsView snilsView:
                            comboBoxItems.Add("СНИЛС");
                            break;
                        case InnView innView:
                            comboBoxItems.Add("ИНН");
                            break;
                        case MilitaryTicketView militaryView:
                            comboBoxItems.Add("Военный билет");
                            break;
                        case ForeignPassportView foreignpassportView:
                            comboBoxItems.Add("Иностранный билет");
                            break;
                    }
                }
                return comboBoxItems;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
