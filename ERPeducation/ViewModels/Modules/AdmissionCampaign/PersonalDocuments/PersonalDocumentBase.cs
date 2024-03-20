using ERPeducation.Common.Windows.WindowDocuments;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments
{
    public abstract class PersonalDocumentBase : ReactiveObject
    {
        [Reactive] public string TextAddChange { get; set; } = "Добавить";
        public string TypeDocument { get; set; } = string.Empty;

        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Fullname { get; set; } = string.Empty;
        [Reactive] public string SelectedGender { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; } = string.Empty;

        public ReactiveCommand<Unit,Unit> ChangeCommand { get; set; }
        public ReactiveCommand<Unit,Unit> DeleteCommand { get; set; }
        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Unit,Unit> AddDocumentCommand { get; set; }

        public event Action<PersonalDocumentBase>? OnChange;
        public event Action<PersonalDocumentBase>? OnDelete;
        public void Delete() => OnDelete?.Invoke(this);
        public void Change() => OnChange?.Invoke(this);


        protected IDialogDocument _dialogDocument;
        public PersonalDocumentBase() 
        {
            if(_dialogDocument == null)
                _dialogDocument = new DialogDocument();
        }
    }
}