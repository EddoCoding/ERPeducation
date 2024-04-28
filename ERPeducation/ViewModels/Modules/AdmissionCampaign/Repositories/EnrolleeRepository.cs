using ERPeducation.Models.AdmissionCampaign.Educations;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions;
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


        ObservableCollection<EducationBase> _education;
        public ObservableCollection<EducationBase> Educations
        {
            get => _education;
            set => this.RaiseAndSetIfChanged(ref _education, value);
        }


        ObservableCollection<DirectionsOfAdmission> _direction;
        public ObservableCollection<DirectionsOfAdmission> Directions
        {
            get => _direction;
            set => this.RaiseAndSetIfChanged(ref _direction, value);
        }


        public EnrolleeRepository()
        {
            Documents = new ObservableCollection<DocumentBase>();
            Educations = new ObservableCollection<EducationBase>();
            Directions = new ObservableCollection<DirectionsOfAdmission>();
        }

        public void CreateDocument(DocumentBase typeDocument) => _documents.Add(typeDocument);
        public void DeleteDocument(DocumentBase document) => _documents.Remove(document);

        public void CreateEducation(EducationBase typeEducation) => _education.Add(typeEducation);
        public void DeleteEducation(EducationBase education) => _education.Remove(education);

        public void CreateDirection(DirectionsOfAdmission direction) => _direction.Add(direction);
        public void DeleteDirection(DirectionsOfAdmission direction) => _direction.Remove(direction);
    }
}