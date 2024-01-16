using ERPeducation.Command;
using ERPeducation.Common.Interface;
using ERPeducation.Interface;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.PersonalInformation;
using System;
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

        public string TitleButton { get; set; } = "Добавить документ";
        #endregion
        #region Команды
        public ICommand OpenPopupForRegistrationDateCommand { get; set; }
        public ICommand AddSnilsCommand { get; set; }
        #endregion

        IConnectionModelService _connectModel;

        public SnilsViewModel(EnrollePersonalInformationViewModel Main, IConnectionModelService connectModel, Action closeWindow)
        {
            _connectModel = connectModel;

            OpenPopupForRegistrationDateCommand = new RelayCommand(() => 
            {
                if (OpenPopupRegistrationDate == false) OpenPopupRegistrationDate = true;
                else OpenPopupRegistrationDate = false;
            });

            AddSnilsCommand = new RelayCommand(() =>
            {
                Main.Documents.Add(_connectModel.GetModel(this));
                closeWindow();
            });
        }
    }
}
