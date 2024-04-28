using ERPeducation.Models.AdmissionCampaign.Educations;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Services
{
    public interface IEnrolleeDocumentService
    {
        void OpenWindowCreateDocument(IEnrolleeRepository repository, string typeDocument);
        void OpenWindowEditDocument(DocumentBase document);

        void OpenWindowCreateEducation(IEnrolleeRepository repository, string education);
        void OpenWindowEditEducation(EducationBase education);

        void OpenWindowCreateDirection(IEnrolleeRepository repository);
        void OpenWindowEditDirection(DirectionsOfAdmission direction);
    }
}