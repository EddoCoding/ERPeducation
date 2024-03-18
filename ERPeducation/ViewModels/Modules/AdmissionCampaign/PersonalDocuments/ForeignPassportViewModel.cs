using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments
{
    public class ForeignPassportViewModel : PersonalDocumentBase
    {
        public string IssuedBy = string.Empty;
        public DateTime DateOfIssue;
        public string Code = string.Empty;
        public string Number = string.Empty;

        public ForeignPassportViewModel(ObservableCollection<PersonalDocumentBase> documents, Action closeWindow)
        {
            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                documents.Add(this);
            });
        }
    }
}