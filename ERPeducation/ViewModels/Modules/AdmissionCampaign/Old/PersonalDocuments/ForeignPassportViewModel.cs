using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Old.PersonalDocuments
{
    [JsonObject]
    public class ForeignPassportViewModel : PersonalDocumentBase
    {
        [Reactive] public string IssuedBy { get; set; } = string.Empty;
        [Reactive] public DateTime DateOfIssue { get; set; }
        [Reactive] public string Code { get; set; } = string.Empty;
        [Reactive] public string Number { get; set; } = string.Empty;


        public ForeignPassportViewModel(ObservableCollection<PersonalDocumentBase> documents, Action closeWindow)
        {
            TypeDocument = "Паспорт иностранного гражданина";

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