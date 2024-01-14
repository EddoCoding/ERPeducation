using ERPeducation.Command;
using System.Windows;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.ContactInformation
{
    public class EnrolleeContactInforamationViewModel
    {
        public string ResidenceAddress { get; set; }
        public string RegistrationAddress { get; set; }
        public long HomePhone { get; set; }
        public long MobilePhone { get; set; }
        public string Mail { get; set; }
        public string AdditionalInformation { get; set; }

        public ICommand command { get; set; }

        public EnrolleeContactInforamationViewModel()
        {
            command = new RelayCommand(() =>
            {
                MessageBox.Show($"Место проживания: {ResidenceAddress}\n" +
                                $"Адрес по прописке: {RegistrationAddress}\n" +
                                $"Домашний телефон: {HomePhone}\n" +
                                $"Мобильный телефон {MobilePhone}\n" +
                                $"Почта: {Mail}\n" +
                                $"Доп. Информация: {AdditionalInformation}");
            });
        }
    }
}