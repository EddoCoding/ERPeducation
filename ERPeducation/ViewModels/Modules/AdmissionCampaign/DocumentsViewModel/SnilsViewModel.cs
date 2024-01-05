using ERPeducation.Command;
using System;
using System.Windows;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class SnilsViewModel
    {
        #region Свойства
        //Свойства данных снилса
        public int Number { get; set; }
        public DateTime RegistrationDate { get; set; }
        #endregion
        #region Команды
        public ICommand AddSnilsCommnad { get; set; }
        #endregion

        public SnilsViewModel(EnrollePersonalInformationViewModel Main)
        {
            AddSnilsCommnad = new RelayCommand(() =>
            {
                MessageBox.Show($"Номер снилса: {Number}\n" +
                    $"Дата регистрации: {RegistrationDate}");
            });
        }
    }
}
