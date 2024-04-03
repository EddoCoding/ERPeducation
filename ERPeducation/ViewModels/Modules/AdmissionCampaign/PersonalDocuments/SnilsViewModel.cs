using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments
{
    [JsonObject]
    public class SnilsViewModel : PersonalDocumentBase
    {
        [Reactive] public string Number { get; set; } = string.Empty;
        [Reactive] public DateTime DateRegistration { get; set; }

        public SnilsViewModel(ObservableCollection<PersonalDocumentBase> documents, Action closeWindow)
        {
            TypeDocument = "Снилс";

            ChangeCommand = ReactiveCommand.Create(Change);
            DeleteCommand = ReactiveCommand.Create(Delete);

            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                documents.Add(this);
                closeWindow();
            });
        }
    }
}