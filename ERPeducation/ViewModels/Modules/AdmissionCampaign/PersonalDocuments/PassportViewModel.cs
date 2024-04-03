using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments
{
    [JsonObject]
    public class PassportViewModel : PersonalDocumentBase
    {
        [Reactive] public string IssuedBy { get; set; } = string.Empty;
        [Reactive] public DateTime DateOfIssue { get; set; }
        [Reactive] public string DepartmentCode { get; set; } = string.Empty;
        [Reactive] public string Series { get; set; } = string.Empty;
        [Reactive] public string Number { get; set; } = string.Empty;


        public PassportViewModel(ObservableCollection<PersonalDocumentBase> document, Action closeWindow) 
        {
            TypeDocument = "Паспорт";

            ChangeCommand = ReactiveCommand.Create(Change);
            DeleteCommand = ReactiveCommand.Create(Delete);

            CloseWindowCommand = ReactiveCommand.Create(() =>
            {
                closeWindow();
            });
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                document.Add(this);
                closeWindow();
            });
        }
    }
}