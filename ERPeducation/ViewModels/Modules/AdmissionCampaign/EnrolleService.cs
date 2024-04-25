using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Old.PersonalDocuments;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class EnrolleService : ReactiveObject, IEnrolleeService
    {
        ObservableCollection<PersonalDocumentBase> _documents;
        public ObservableCollection<PersonalDocumentBase> Documents
        {
            get => _documents;
            set => this.RaiseAndSetIfChanged(ref _documents, value);
        }

        public EnrolleService()
        {
            Documents = new ObservableCollection<PersonalDocumentBase>();
        }




        public void CreateDocument(PersonalDocumentBase document) => Documents.Add(document);
    }
}