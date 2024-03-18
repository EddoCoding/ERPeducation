using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments
{
    public class InnViewModel : PersonalDocumentBase
    {
        public string NumberInn = string.Empty;
        public DateTime DateAssigned;
        public string Series = string.Empty;

        public InnViewModel(ObservableCollection<PersonalDocumentBase> documents, Action closeWindow)
        {
            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                documents.Add(this);
            });
        }
    }
}