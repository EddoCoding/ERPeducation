using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments
{
    public class PassportViewModel : PersonalDocumentBase
    {
        public string IssuedBy { get; set; } = string.Empty;
        public DateTime DateOfIssue { get; set; }
        public string DepartmentCode { get; set; } = string.Empty;
        public string Series { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;

        public PassportViewModel(ObservableCollection<PersonalDocumentBase> documents, Action closeWindow) 
        {
            TypeDocument = "Паспорт";
            SurName = "Фамилия";
            Name = "Имя";
            MiddleName = "Отчество";
            Gender = "Муж";
            DateOfBirth = DateTime.Now;
            PlaceOfBirth = "г. Москва";
            IssuedBy = "ОУФМС";
            DateOfIssue = DateTime.Now;
            DepartmentCode = "123456789";
            Series = "1234";
            Number = "999999";



            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                documents.Add(this);
            });
        }
    }
}