﻿using ERPeducation.Common.Interface;
using ERPeducation.Common.Windows.WindowDocuments;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments
{
    public abstract class PersonalDocumentBase : ReactiveObject, ISubmitted
    {
        [Reactive] public string TextAddChange { get; set; } = "Добавить";
        public string TypeDocument { get; set; } = string.Empty;

        [Reactive] public string SurName { get; set; } = string.Empty;
        [Reactive] public string Name { get; set; } = string.Empty;
        [Reactive] public string MiddleName { get; set; } = string.Empty;
        [Reactive] public string SelectedGender { get; set; }

        [Reactive] public DateTime DateOfBirth { get; set; }
        [Reactive] public string PlaceOfBirth { get; set; } = string.Empty;

        [Reactive] public string SelectedSee { get; set; }
        [Reactive] public int Quantity { get; set; }


        public ReactiveCommand<Unit,Unit> ChangeCommand { get; set; }
        public ReactiveCommand<Unit,Unit> DeleteCommand { get; set; }
        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Unit,Unit> AddDocumentCommand { get; set; }

        public event Action<PersonalDocumentBase>? OnChange;
        public event Action<PersonalDocumentBase>? OnDelete;

        public void Change() => OnChange?.Invoke(this);
        public void Delete() => OnDelete?.Invoke(this);


        protected IDialogDocument _dialogDocument;
        public PersonalDocumentBase() 
        {
            if(_dialogDocument == null)
                _dialogDocument = new DialogDocument();
        }
    }
}