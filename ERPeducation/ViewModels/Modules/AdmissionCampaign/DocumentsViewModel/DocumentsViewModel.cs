using ERPeducation.Command;
using ERPeducation.Common.Windows;
using ERPeducation.Interface;
using ERPeducation.Views.AdmissionCampaign.DocumentsView;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class DocumentsViewModel : INPC
    {
        #region Свойства
        public string[] Docs { get; set; } = { "Паспорт", "СНИЛС", "ИНН", "Иностранный паспорт" };

        string valueComboBox = string.Empty;
        public string ValueComboBox
        {
            get => valueComboBox;
            set
            {
                valueComboBox = value;
                OnPropertyChanged(nameof(ValueComboBox));
                GetView();
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
        #endregion
        #region Команды
        public ICommand CloseWindowCommand { get; set; }
        #endregion

        public DocumentsViewModel(EnrollePersonalInformationViewModel enrolleeViewModel, Window window)
        {
            this.enrolleeViewModel = enrolleeViewModel;
            CloseWindowCommand = new RelayCommand(() => { window.Close(); });
        }

        void GetView()
        {
            switch (ValueComboBox)
            {
                case "Паспорт":
                    UserControl = new PassportView(new PassportViewModel(enrolleeViewModel));
                    break;
                case "СНИЛС":
                    UserControl = new SnilsView(new SnilsViewModel(enrolleeViewModel));
                    break;
                case "ИНН":
                    UserControl = new InnView(new InnViewModel(enrolleeViewModel));
                    break;
                case "Иностранный паспорт":
                    UserControl = new ForeignPassportView(new ForeignPassportViewModel(enrolleeViewModel));
                    break;
            }
        }
    }
}