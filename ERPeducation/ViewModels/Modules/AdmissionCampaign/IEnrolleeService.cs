using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Old.PersonalDocuments;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public interface IEnrolleeService
    {
        public ObservableCollection<PersonalDocumentBase> Documents { get; set; }

        void CreateDocument(PersonalDocumentBase document);
    }
}
