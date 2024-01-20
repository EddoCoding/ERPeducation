using ERPeducation.Common.Interface.DialogPersonal;
using ERPeducation.Interface;
using ERPeducation.Models.AdmissionCampaign.Documents;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.PersonalInformation
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

        DocsBase selectedDocument;
        public DocsBase SelectedDocument
        {
            get => selectedDocument;
            set
            {
                selectedDocument = value;
                OnPropertyChanged(nameof(SelectedDocument));
            }
        }
        #endregion
        #region Команды
        public ReactiveCommand<Unit, Unit> OpenPopupCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AddDocumentCommand { get; set; }
        public ReactiveCommand<Unit, Unit> DeleteDocumentCommand { get; set; }
        public ReactiveCommand<Unit, Unit> EditDocumentCommand { get; set; }
        #endregion

        IDialogService _dialogService;
        public EnrollePersonalInformationViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            OpenPopupCommand = ReactiveCommand.Create(() => 
            {
                if (OpenPopup == false) OpenPopup = true;
                else OpenPopup = false;
            });
            AddDocumentCommand = ReactiveCommand.Create(OpenWindowDocuments);
            DeleteDocumentCommand = ReactiveCommand.Create(DeleteDocument);
            EditDocumentCommand = ReactiveCommand.Create(EditDocument);
        }

        void OpenWindowDocuments() => _dialogService.OpenWindow(this);
        void DeleteDocument() => Documents.Remove(SelectedDocument);
        void EditDocument() => _dialogService.OpenWindowEditPersonalDocument(SelectedDocument, this);
    }
}