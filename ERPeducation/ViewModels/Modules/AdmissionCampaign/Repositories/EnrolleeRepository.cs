using ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class EnrolleeRepository : ReactiveObject, IEnrolleeRepository
    {
        ObservableCollection<DocumentBase> _documents;
        public ObservableCollection<DocumentBase> Documents
        {
            get => _documents;
            set => this.RaiseAndSetIfChanged(ref _documents, value);
        }

        public EnrolleeRepository()
        {
            Documents = new ObservableCollection<DocumentBase>();
        }

        public void CreateDocument(string typeDocument) { }
    }
}