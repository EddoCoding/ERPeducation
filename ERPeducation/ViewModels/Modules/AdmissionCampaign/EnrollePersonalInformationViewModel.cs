using System;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class EnrollePersonalInformationViewModel
    {
        public string ValueComboBox { get; set; } = string.Empty;
        public string[] Gender { get; set; } = { "Муж", "Жен"};
        DateTime dateOfBirth = new DateTime();
        public DateTime DateOfBirth 
        {
            get => dateOfBirth;
            set
            {
                dateOfBirth = value;
                MessageBox.Show($"Выбрана дата: {DateOfBirth}", "Сообщение", MessageBoxButton.OK);
            }
        }
    }
}
