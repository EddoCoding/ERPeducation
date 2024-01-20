using ReactiveUI;
using System.Reactive;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.ContactInformation
{
    public class EnrolleeContactInforamationViewModel : ReactiveObject
    { 
        public string ResidenceAddress { get; set; }
        public string RegistrationAddress { get; set; }
        public long HomePhone { get; set; }
        public long MobilePhone { get; set; }
        public string Mail { get; set; }
        public string AdditionalInformation { get; set; }

        public ReactiveCommand<Unit, Unit> command { get; set; }
        
        public EnrolleeContactInforamationViewModel()
        {
            command = ReactiveCommand.Create(() => 
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