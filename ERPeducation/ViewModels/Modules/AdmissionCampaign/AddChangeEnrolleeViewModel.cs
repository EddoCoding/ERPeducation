using ERPeducation.Common.Windows.WindowDocuments;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments;
using ERPeducation.Views.AdmissionCampaign;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Controls;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class AddChangeEnrolleeViewModel : ReactiveObject
    {
        #region Личная Информация
        public string SurName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }

        [Reactive] public string SelectedGender { get; set; }
        [Reactive] public bool Popup { get; set; }
        [Reactive] public DateTime DateOfBirth { get; set; }

        [Reactive] public string Citizenship { get; set; }
        [Reactive] public bool IsEnabled{ get; set; } = true;
        [Reactive] public DateTime DoCitizenship { get; set; }
        public ObservableCollection<PersonalDocumentBase> Documents { get; set; }


        PersonalDocumentBase selectedDocument;
        public PersonalDocumentBase SelectedDocument
        {
            get => selectedDocument;
            set
            {
                selectedDocument = value;
                _dialogDocument.GetUserControlDocument(UserControlDocument, SelectedDocument);
            }
        }

        [Reactive] public UserControl UserControlDocument { get; set; }

        #endregion
        #region Контактная Информация
        #endregion
        #region Образование
        #endregion
        #region Поступление
        #endregion
        #region Документы на печать
        #endregion
        #region Результаты испытаний
        #endregion

        #region Команды Личная Информация
        public ReactiveCommand<Unit,Unit> OpenPopupCommand { get; set; }
        public ReactiveCommand<Unit,Unit> OpenValueCommand { get; set; }
        public ReactiveCommand<Unit,Unit> DelValueCommand { get; set; }
        public ReactiveCommand<string,Unit> AddDocument { get; set; }
        #endregion
        #region Команды Персональная Информация
        #endregion
        #region Команды Образование
        #endregion
        #region Команды Поступление
        #endregion
        #region Команды Документы на печать
        #endregion
        #region Команды Результаты испытаний
        #endregion

        IDialogDocument _dialogDocument;
        public AddChangeEnrolleeViewModel(IDialogDocument dialogDocument, ObservableCollection<EnrolleeViewModel> enrollees)
        {
            _dialogDocument = dialogDocument;

            UserControlDocument = new UserControl();

            Documents = new ObservableCollection<PersonalDocumentBase>();
            Documents.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (PersonalDocumentBase item in e.OldItems) item.OnDelete -= deleteDocument;
                if (e.NewItems != null) foreach (PersonalDocumentBase item in e.NewItems) item.OnDelete += deleteDocument;
            };
            InitializingCommandsPersonalInfo();
        }

        void InitializingCommandsPersonalInfo()
        {
            OpenPopupCommand = ReactiveCommand.Create(() =>
            {
                if (!Popup) Popup = true;
                else Popup = false;
            });
            OpenValueCommand = ReactiveCommand.Create(() =>
            {
                IsEnabled = true;
            });
            DelValueCommand = ReactiveCommand.Create(() =>
            {
                Citizenship = string.Empty;
                DoCitizenship = DateTime.MinValue;
                IsEnabled = false;
            });
            AddDocument = ReactiveCommand.Create<string>(parameter =>
            {
                if(parameter == "Passport") _dialogDocument.GetPassport(Documents);
                if(parameter == "Snils") _dialogDocument.GetSnils(Documents);
                if(parameter == "Inn") _dialogDocument.GetInn(Documents);
                if(parameter == "ForeignPassport") _dialogDocument.GetForeignPassport(Documents);
            });
        }
        void deleteDocument(PersonalDocumentBase document) => Documents.Remove(document);
    }
}