using ERPeducation.Common.Interface;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments
{
    public class InnViewModel : PersonalDocumentBase
    {
        [Reactive] public string NumberInn { get; set; } = string.Empty;
        [Reactive] public DateTime DateAssigned { get; set; }
        [Reactive] public string Series { get; set; } = string.Empty;
        [Reactive] public string Number { get; set; } = string.Empty;


        //КОНСТРУКТОР ДЛЯ ИЗМЕНЕНИЯ ОБЪЕКТА
        public InnViewModel(InnViewModel document, Action closeWindow)
        {
            TextAddChange = "Изменить";

            TypeDocument = document.TypeDocument;
            SurName = document.SurName;
            Name = document.Name;
            MiddleName = document.MiddleName;
            SelectedGender = document.SelectedGender;
            DateOfBirth = document.DateOfBirth;
            PlaceOfBirth = document.PlaceOfBirth;
            NumberInn = document.NumberInn;
            DateAssigned = document.DateAssigned;
            Series = document.Series;
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
                document.NumberInn = NumberInn;
                document.DateAssigned = DateAssigned;
                document.Series = Series;
                document.Number = Number;

                closeWindow();
            });
        }

        //ОСНОВНОЙ КОНСТРУКТОР ДЛЯ НОВОГО ДОКУМЕНТА
        public InnViewModel(ObservableCollection<PersonalDocumentBase> documents, ObservableCollection<ISubmitted> submittedDocuments, Action closeWindow)
        {
            TypeDocument = "ИНН";

            OnChange += document => _dialogDocument.GetInn(this);

            ChangeCommand = ReactiveCommand.Create(Change);
            DeleteCommand = ReactiveCommand.Create(Delete);

            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                documents.Add(this);
                submittedDocuments.Add(this);
                CloseWindowCommand.Execute().Subscribe();
            });
        }
    }
}