using ERPeducation.Common.Command;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments
{
    public class SnilsViewModel : PersonalDocumentBase
    {
        public string Number { get; set; } = string.Empty;
        public DateTime DateRegistration { get; set; }

        public SnilsViewModel(ObservableCollection<PersonalDocumentBase> documents, Action closeWindow)
        {
            TypeDocument = "Снилс";

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