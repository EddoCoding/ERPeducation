namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Services
{
    public interface IEnrolleeDocumentService
    {
        void OpenWindowCreateDocument(IEnrolleeRepository repository, string typeDocument);
    }
}