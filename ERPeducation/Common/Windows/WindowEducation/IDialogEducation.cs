using ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Windows.WindowEducation
{
    public interface IDialogEducation
    {
        void GetBasicGeneral(ObservableCollection<EducationDocumentBase> education);
        void GetBasicAverage(ObservableCollection<EducationDocumentBase> education);
        void GetSpo(ObservableCollection<EducationDocumentBase> education);
        void GetUndergraduate(ObservableCollection<EducationDocumentBase> education);
        void GetMaster(ObservableCollection<EducationDocumentBase> education);
        void GetSpecialty(ObservableCollection<EducationDocumentBase> education);
    }
}