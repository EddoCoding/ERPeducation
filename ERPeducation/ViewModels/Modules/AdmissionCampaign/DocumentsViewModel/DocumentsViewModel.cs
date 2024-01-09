﻿using ERPeducation.Command;
using ERPeducation.Common.Interface;
using ERPeducation.Interface;
using ERPeducation.Views.AdmissionCampaign.DocumentsView;
using System;
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
        #endregion
        #region Команды
        public ICommand CloseWindowCommand { get; set; }
        #endregion

        IDialogService _dialogService;
        public DocumentsViewModel(IDialogService dialogService, EnrollePersonalInformationViewModel enrolleeViewModel, Action closeWindow)
        {
            _dialogService = dialogService;

            this.enrolleeViewModel = enrolleeViewModel;
            CloseWindowCommand = new RelayCommand(() => { closeWindow(); });
        }

        void GetViewAndViewModel()
        {
            switch (ValueComboBox)
            {
                case "Паспорт":
                    UserControl = _dialogService.GetUserControlForDocuments(ValueComboBox);
                    break;
                case "СНИЛС":
                    UserControl = _dialogService.GetUserControlForDocuments(ValueComboBox);
                    break;
                case "ИНН":
                    UserControl = _dialogService.GetUserControlForDocuments(ValueComboBox);
                    break;
                case "Иностранный паспорт":
                    UserControl = _dialogService.GetUserControlForDocuments(ValueComboBox);
                    break;
            }
        }
    }
}