using ERPeducation.Common.Command;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments
{
    public class PassportViewModel : PersonalDocumentBase
    {
        public string IssuedBy { get; set; } = string.Empty;
        public DateTime DateOfIssue { get; set; }
        [Reactive] public string DepartmentCode { get; set; } = string.Empty;
        public string Series { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;

        public PassportViewModel(ObservableCollection<PersonalDocumentBase> documents, Action closeWindow) 
        {
            TypeDocument = "Паспорт";

            ChangeCommand = ReactiveCommand.Create(NotReady.Message);
            DeleteCommand = ReactiveCommand.Create(NotReady.Message);
            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                documents.Add(this);
                CloseWindowCommand.Execute().Subscribe();
            });
        }
    }
}