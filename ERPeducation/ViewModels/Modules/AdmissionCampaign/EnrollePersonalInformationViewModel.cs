using ERPeducation.Command;
using ERPeducation.Common.Interface;
using ERPeducation.Interface;
using ERPeducation.Models.AdmissionCampaign.Documents;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class EnrollePersonalInformationViewModel : INPC
    {
        #region Свойства контролов
        string surName;
        public string SurName
        {
            get => surName;
            set
            {
                surName = value;
                OnPropertyChanged(nameof(SurName));
            }
        }
        string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        string middleName;
        public string MiddleName
        {
            get => middleName;
            set
            {
                middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }

        public string[] Gender { get; set; } = { "Муж", "Жен" };

        string valueComboBox = string.Empty;
        public string ValueComboBox
        {
            get => valueComboBox;
            set
            {
                valueComboBox = value;
                OnPropertyChanged(nameof(ValueComboBox));
            }
        }

        DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                dateOfBirth = value;
                IsValidFrom = dateOfBirth;
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

        string citizenship;
        public string Citizenship
        {
            get => citizenship;
            set
            {
                citizenship = value;
                OnPropertyChanged(nameof(Citizenship));
            }
        }

        DateTime isValidFrom;
        public DateTime IsValidFrom
        {
            get => isValidFrom;
            set
            {
                isValidFrom = value;
                OnPropertyChanged(nameof(IsValidFrom));
            }
        }

        private bool radioButtonCitizenship = true;
        public bool RadioButtonСitizenship
        {
            get => radioButtonCitizenship;
            set
            {
                if (value != radioButtonCitizenship)
                {
                    radioButtonCitizenship = value;
                    if (radioButtonCitizenship)
                    {
                        radioButtonWithoutСitizenship = false;
                        OnPropertyChanged(nameof(RadioButtonWithoutСitizenship));
                    }
                    OnPropertyChanged(nameof(RadioButtonСitizenship));
                }
            }
        }

        private bool radioButtonWithoutСitizenship;
        public bool RadioButtonWithoutСitizenship
        {
            get => radioButtonWithoutСitizenship;
            set
            {
                if (value != radioButtonWithoutСitizenship)
                {
                    radioButtonWithoutСitizenship = value;
                    if (radioButtonWithoutСitizenship)
                    {
                        radioButtonCitizenship = false;
                        OnPropertyChanged(nameof(RadioButtonСitizenship));
                    }
                    OnPropertyChanged(nameof(RadioButtonWithoutСitizenship));
                }
            }
        }

        public ObservableCollection<DocsBase> Documents { get; set; } = new ObservableCollection<DocsBase>();

        DocsBase docsBase;
        public DocsBase DocsBase
        {
            get => docsBase;
            set
            {
                docsBase = value;
                OnPropertyChanged(nameof(DocsBase));
            }
        }
        #endregion
        #region Команды
        public ICommand OpenPopupCommand { get; set; }
        public ICommand ForCheck { get; set; }
        public ICommand AddDocumentCommand { get; set; }
        #endregion

        IDialogService _dialogService;
        public EnrollePersonalInformationViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            AddDocumentCommand = new RelayCommand(OpenWindowDocuments);
        }

        void OpenWindowDocuments() => _dialogService.OpenWindow(this);
    }
}