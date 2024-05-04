using ERPeducation.Models.AdmissionCampaign.Direction;
using ERPeducation.Models.AdmissionCampaign.Educations;
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


        ObservableCollection<DirectionOfAdmission> _direction;
        public ObservableCollection<DirectionOfAdmission> Directions
        {
            get => _direction;
            set => this.RaiseAndSetIfChanged(ref _direction, value);
        }


        public EnrolleeRepository()
        {
            Documents = new ObservableCollection<DocumentBase>();
            Educations = new ObservableCollection<EducationBase>();
            Directions = new ObservableCollection<DirectionOfAdmission>();
        }

        public void CreateDocument(DocumentBase typeDocument) => _documents.Add(typeDocument);
        public void DeleteDocument(DocumentBase document) => _documents.Remove(document);

        public void CreateEducation(EducationBase typeEducation) => _education.Add(typeEducation);
        public void DeleteEducation(EducationBase education) => _education.Remove(education);

        public void CreateDirection(DirectionOfAdmission direction) => _direction.Add(direction);
        public void DeleteDirection(DirectionOfAdmission direction) => _direction.Remove(direction);
    }
}