using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments
{
    public class PassportViewModel : PersonalDocumentBase
    {
        [Reactive] public string IssuedBy { get; set; } = string.Empty;
        [Reactive] public DateTime DateOfIssue { get; set; }
        [Reactive] public string DepartmentCode { get; set; } = string.Empty;
        [Reactive] public string Series { get; set; } = string.Empty;
        [Reactive] public string Number { get; set; } = string.Empty;


        //КОНСТРУКТОР ДЛЯ ИЗМЕНЕНИЯ ОБЪЕКТА
        public PassportViewModel(PassportViewModel document, Action closeWindow)
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
            DepartmentCode = document.DepartmentCode;
            Series = document.Series;
            Number = document.Number;

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
                document.DepartmentCode = DepartmentCode;
                document.Series = Series;
                document.Number = Number;

                closeWindow();
            });
        }

        //ОСНОВНОЙ КОНСТРУКТОР ДЛЯ НОВОГО ДОКУМЕНТА
        public PassportViewModel(ObservableCollection<PersonalDocumentBase> document, Action closeWindow) 
        {
            TypeDocument = "Паспорт";

            OnChange += document => _dialogDocument.GetPassport(this);

            ChangeCommand = ReactiveCommand.Create(Change);
            DeleteCommand = ReactiveCommand.Create(Delete);

            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                document.Add(this);
                closeWindow();
            });
        }
    }
}