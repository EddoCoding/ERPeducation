using ERPeducation.Models.AdmissionCampaign.Direction;
using ERPeducation.Models.AdmissionCampaign.Educations;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public interface IEnrolleeRepository
    {
        public ObservableCollection<DocumentBase> Documents { get; set; }
        void CreateDocument(DocumentBase typeDocument);
        void DeleteDocument(DocumentBase document);

        public ObservableCollection<EducationBase> Educations { get; set; }
        void CreateEducation (EducationBase typeEducation);
        void DeleteEducation (EducationBase education);

        public ObservableCollection<DirectionOfAdmission> Directions { get; set; }
        void CreateDirection(DirectionOfAdmission direction);
        void DeleteDirection(DirectionOfAdmission direction);
    }
}