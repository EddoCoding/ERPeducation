using ERPeducation.Command;
using ERPeducation.Common.Interface;
using ERPeducation.Interface;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.PersonalInformation;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class DocumentsViewModel : INPC
    {
        #region Свойства
        public string TypeDocument { get; set; } // Свойство применяется в окне изменения документа
        public string[] Docs { get; set; } = { "Паспорт", "СНИЛС", "ИНН", "Иностранный паспорт" };

        string valueComboBox = string.Empty;
        public string ValueComboBox
        {
            get => valueComboBox;
            set
            {
                valueComboBox = value;
                OnPropertyChanged(nameof(ValueComboBox));
                GetViewAndViewModel();
            }
        }

        UserControl userControl;
        public UserControl UserControl
        {
            get => userControl;
            set
            {
                userControl = value;
                OnPropertyChanged(nameof(UserControl));
            }
        }

        public EnrollePersonalInformationViewModel enrolleeViewModel { get; set; }

        Action closeWindow;
        #endregion
        #region Команды
        public ICommand CloseWindowCommand { get; set; }
        #endregion

        IUserControlService _userControlService;
        public DocumentsViewModel(IUserControlService userControlService, EnrollePersonalInformationViewModel enrolleeViewModel, Action closeWindow)
        {
            _userControlService = userControlService;

            this.closeWindow = closeWindow;
            this.enrolleeViewModel = enrolleeViewModel;
            CloseWindowCommand = new RelayCommand(CloseWindowDocuments);
        }

        void GetViewAndViewModel()
        {
            switch (ValueComboBox)
            {
                case "Паспорт":
                    UserControl = _userControlService.GetUserControlForDocuments(ValueComboBox, enrolleeViewModel, closeWindow);
                    break;
                case "СНИЛС":
                    UserControl = _userControlService.GetUserControlForDocuments(ValueComboBox, enrolleeViewModel, closeWindow);
                    break;
                case "ИНН":
                    UserControl = _userControlService.GetUserControlForDocuments(ValueComboBox, enrolleeViewModel, closeWindow);
                    break;
                case "Иностранный паспорт":
                    UserControl = _userControlService.GetUserControlForDocuments(ValueComboBox, enrolleeViewModel, closeWindow);
                    break;
            }
        }

        void CloseWindowDocuments() => closeWindow();
    }
}