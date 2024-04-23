using ERPeducation.Common.Windows.WindowDocuments;
using ERPeducation.Models;
using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Old.PersonalDocuments
{
    [JsonObject]
    public class PersonalDocumentBase : Check
    {
        [Reactive] public string TextAddChange { get; set; } = "Добавить";
        public string TypeDocument { get; set; } = string.Empty;

        [Reactive] public string SurName { get; set; } = string.Empty;
        [Reactive] public string Name { get; set; } = string.Empty;
        [Reactive] public string MiddleName { get; set; } = string.Empty;
        [Reactive] public string SelectedGender { get; set; }

        [Reactive] public DateTime DateOfBirth { get; set; }
        [Reactive] public string PlaceOfBirth { get; set; } = string.Empty;


        [JsonIgnore] public ReactiveCommand<Unit, Unit> ChangeCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit, Unit> DeleteCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit, Unit> AddDocumentCommand { get; set; }

        public event Action<PersonalDocumentBase>? OnChange;
        public event Action<PersonalDocumentBase>? OnDelete;

        public void Change() => OnChange?.Invoke(this);
        public void Delete() => OnDelete?.Invoke(this);


        protected IDialogDocument _dialogDocument;
        public PersonalDocumentBase()
        {
            if (_dialogDocument == null)
                _dialogDocument = new DialogDocument();

            OnChange += changeDocument;

            ChangeCommand = ReactiveCommand.Create(() =>
            {
                OnChange?.Invoke(this);
            });
            DeleteCommand = ReactiveCommand.Create(() =>
            {
                OnDelete?.Invoke(this);
            });
        }

        void changeDocument(PersonalDocumentBase document)
        {
            if (document.TypeDocument == "Паспорт") _dialogDocument.GetPassport(document);
            if (document.TypeDocument == "Снилс") _dialogDocument.GetSnils(document);
            if (document.TypeDocument == "ИНН") _dialogDocument.GetInn(document);
            if (document.TypeDocument == "Паспорт иностранного гражданина") _dialogDocument.GetForeignPassport(document);
        }
    }
}