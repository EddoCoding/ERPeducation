using ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public interface IEnrolleeRepository
    {
        public ObservableCollection<DocumentBase> Documents { get; set; }
        void CreateDocument(DocumentBase typeDocument);
    }
}