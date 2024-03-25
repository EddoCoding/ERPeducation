using ERPeducation.Common.Interface;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.Common.Windows.WindowEducation
{
    public interface IDialogEducation
    {
        void GetBasicGeneral(ObservableCollection<EducationDocumentBase> education, ObservableCollection<ISubmitted> submittedDocuments);
        void GetBasicGeneral(BasicGeneralEducationViewModel education);

        void GetBasicAverage(ObservableCollection<EducationDocumentBase> education, ObservableCollection<ISubmitted> submittedDocuments);
        void GetBasicAverage(BasicAverageEducationViewModel education);

        void GetSpo(ObservableCollection<EducationDocumentBase> education, ObservableCollection<ISubmitted> submittedDocuments);
        void GetSpo(EducationSpoViewModel education);

        void GetUndergraduate(ObservableCollection<EducationDocumentBase> education, ObservableCollection<ISubmitted> submittedDocuments);
        void GetUndergraduate(EducationUndergraduateViewModel education);

        void GetMaster(ObservableCollection<EducationDocumentBase> education, ObservableCollection<ISubmitted> submittedDocuments);
        void GetMaster(EducationMasterViewModel education);

        void GetSpecialty(ObservableCollection<EducationDocumentBase> education, ObservableCollection<ISubmitted> submittedDocuments);
        void GetSpecialty(EducationSpecialtyViewModel education);

        void GetUserControlEducation(UserControl userControl, EducationDocumentBase document);
    }
}