using ERPeducation.Common.Windows.WindowDocuments;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments;
using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Controls;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Enrollee
{
    [JsonObject]
    public class EnrolleePersonalInfoViewModel : ReactiveObject
    {
        [Reactive] public string SurName { get; set; } = string.Empty;
        [Reactive] public string Name { get; set; } = string.Empty;
        [Reactive] public string MiddleName { get; set; } = string.Empty;

        [Reactive] public string SelectedGender { get; set; } = string.Empty;
        [Reactive] public bool Popup { get; set; }
        [Reactive] public DateTime DateOfBirth { get; set; }

        [Reactive] public string Citizenship { get; set; } = string.Empty;
        [Reactive] public bool IsEnabled { get; set; } = true;
        [Reactive] public DateTime DoCitizenship { get; set; }

        public ObservableCollection<PersonalDocumentBase> Documents { get; set; }


        PersonalDocumentBase selectedDocument;
        [JsonIgnore] public PersonalDocumentBase SelectedDocument
        {
            get => selectedDocument;
            set
            {
                selectedDocument = value;
                _dialogDocument.GetUserControlDocument(UserControlDocument, SelectedDocument);
            }
        }

        [JsonIgnore] public UserControl UserControlDocument { get; set; }


        [JsonIgnore] public ReactiveCommand<Unit, Unit> OpenPopupCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit, Unit> OpenValueCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit, Unit> DelValueCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<string, Unit> AddDocumentCommand { get; set; }


        IDialogDocument _dialogDocument;
        public EnrolleePersonalInfoViewModel()
        {
            _dialogDocument = new DialogDocument();

            Documents = new ObservableCollection<PersonalDocumentBase>();
            Documents.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (PersonalDocumentBase item in e.OldItems) item.OnDelete -= deleteDocument;
                if (e.NewItems != null) foreach (PersonalDocumentBase item in e.NewItems) item.OnDelete += deleteDocument;
            };
            UserControlDocument = new UserControl();

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

            AddDocumentCommand = ReactiveCommand.Create<string>(parameter =>
            {
                switch (parameter)
                {
                    case "Passport":
                        _dialogDocument.GetPassport(Documents);
                        break;
                    case "Snils":
                        _dialogDocument.GetSnils(Documents);
                        break;
                    case "Inn":
                        _dialogDocument.GetInn(Documents);
                        break;
                    case "ForeignPassport":
                        _dialogDocument.GetForeignPassport(Documents);
                        break;
                }
            });
        }

        void deleteDocument(PersonalDocumentBase document) => Documents.Remove(document);
    }
}