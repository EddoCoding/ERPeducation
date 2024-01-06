using ERPeducation.Command;
using ERPeducation.Interface;
using System;
using System.Windows;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class SnilsViewModel : INPC
    {
        #region Свойства
        //Свойства данных снилса
        public string Number { get; set; }

        DateTime registrationDate;
        public DateTime RegistrationDate
        {
            get => registrationDate;
            set
            {
                registrationDate = value;
                OnPropertyChanged(nameof(RegistrationDate));
            }
        }

        private bool openPopupRegistrationDate;
        public bool OpenPopupRegistrationDate
        {
            get => openPopupRegistrationDate;
            set
            {
                openPopupRegistrationDate = value;
                OnPropertyChanged(nameof(OpenPopupRegistrationDate));
            }
        }
        #endregion
        #region Команды
        public ICommand OpenPopupForRegistrationDateCommand { get; set; }
        public ICommand AddSnilsCommand { get; set; }
        #endregion

        public SnilsViewModel(EnrollePersonalInformationViewModel Main)
        {
            OpenPopupForRegistrationDateCommand = new RelayCommand(() => 
            {
                if (OpenPopupRegistrationDate == false) OpenPopupRegistrationDate = true;
                else OpenPopupRegistrationDate = false;
            });

            AddSnilsCommand = new RelayCommand(() =>
            {
                MessageBox.Show($"Номер снилса: {Number}\n" +
                    $"Дата регистрации: {RegistrationDate}");
            });
        }
    }
}
