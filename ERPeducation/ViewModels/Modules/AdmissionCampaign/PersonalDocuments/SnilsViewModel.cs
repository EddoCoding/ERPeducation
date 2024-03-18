using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments
{
    public class SnilsViewModel : PersonalDocumentBase
    {
        public string Number = string.Empty;
        public DateTime RegistrationDate;

        public SnilsViewModel(ObservableCollection<PersonalDocumentBase> documents, Action closeWindow)
        {
            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                documents.Add(this);
            });
        }
    }
}