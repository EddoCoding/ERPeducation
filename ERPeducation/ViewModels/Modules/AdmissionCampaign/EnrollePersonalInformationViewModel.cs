using ERPeducation.Command;
using ERPeducation.Interface;
using System;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class EnrollePersonalInformationViewModel : INPC
    {
        #region Свойства
        public string ValueComboBox { get; set; } = string.Empty;
        public string[] Gender { get; set; } = { "Муж", "Жен" };
        DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }
        private bool openPopup;
        public bool OpenPopup
        {
            get => openPopup;
            set
            {
                openPopup = value;
                OnPropertyChanged(nameof(OpenPopup));
            }
        }
        #endregion
        #region Команды
        public ICommand OpenPopupCommand { get; set; }
        #endregion

        public EnrollePersonalInformationViewModel()
        {
            OpenPopupCommand = new RelayCommand(() =>
            {
                if (OpenPopup == false) OpenPopup = true;
                else OpenPopup = false;
            });
        }
    }
}