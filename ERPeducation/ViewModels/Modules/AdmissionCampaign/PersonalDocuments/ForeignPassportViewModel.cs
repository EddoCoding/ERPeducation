﻿using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments
{
    public class ForeignPassportViewModel : PersonalDocumentBase
    {
        public string IssuedBy { get; set; } = string.Empty;
        public DateTime DateOfIssue { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;


        //КОНСТРУКТОР ДЛЯ ИЗМЕНЕНИЯ ОБЪЕКТА
        public ForeignPassportViewModel(ForeignPassportViewModel document, Action closeWindow)
        {
            TextAddChange = "Изменить";

            TypeDocument = document.TypeDocument;
            SurName = document.SurName;
            Name = document.Name;
            MiddleName = document.MiddleName;
            SelectedGender = document.SelectedGender;
            DateOfBirth = document.DateOfBirth;
            PlaceOfBirth = document.PlaceOfBirth;
            IssuedBy = document.IssuedBy;
            DateOfIssue = document.DateOfIssue;
            Code = document.Code;
            Number = document.Number;

            ChangeCommand = ReactiveCommand.Create(Change);
            DeleteCommand = ReactiveCommand.Create(Delete);
            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                document.SurName = SurName;
                document.Name = Name;
                document.MiddleName = MiddleName;
                document.SelectedGender = SelectedGender;
                document.DateOfBirth = DateOfBirth;
                document.PlaceOfBirth = PlaceOfBirth;
                document.IssuedBy = IssuedBy;
                document.DateOfIssue = DateOfIssue;
                document.Code = Code;
                document.Number = Number;

                closeWindow();
            });
        }

        //ОСНОВНОЙ КОНСТРУКТОР ДЛЯ НОВОГО ДОКУМЕНТА
        public ForeignPassportViewModel(ObservableCollection<PersonalDocumentBase> documents, Action closeWindow)
        {
            TypeDocument = "Паспорт иностранного гражданина";

            OnChange += document => _dialogDocument.GetForeignPassport(this);

            ChangeCommand = ReactiveCommand.Create(Change);
            DeleteCommand = ReactiveCommand.Create(Delete);
            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                documents.Add(this);
                CloseWindowCommand.Execute().Subscribe();
            });
        }
    }
}