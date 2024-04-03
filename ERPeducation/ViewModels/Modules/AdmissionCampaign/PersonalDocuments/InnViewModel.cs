using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments
{
    [JsonObject]
    public class InnViewModel : PersonalDocumentBase
    {
        [Reactive] public string NumberInn { get; set; } = string.Empty;
        [Reactive] public DateTime DateAssigned { get; set; }
        [Reactive] public string Series { get; set; } = string.Empty;
        [Reactive] public string Number { get; set; } = string.Empty;


        public InnViewModel(ObservableCollection<PersonalDocumentBase> documents, Action closeWindow)
        {
            TypeDocument = "ИНН";

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