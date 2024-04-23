using ERPeducation.ViewModels.Modules.AdmissionCampaign.Old.EducationDocuments;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.Common.Windows.WindowEducation
{
    public interface IDialogEducation
    {
        void GetBasicGeneral(ObservableCollection<EducationDocumentBase> education);
        void GetBasicGeneral(EducationDocumentBase education);

        void GetBasicAverage(ObservableCollection<EducationDocumentBase> education);
        void GetBasicAverage(EducationDocumentBase education);

        void GetSpo(ObservableCollection<EducationDocumentBase> education);
        void GetSpo(EducationDocumentBase education);

        void GetUndergraduate(ObservableCollection<EducationDocumentBase> education);
        void GetUndergraduate(EducationDocumentBase education);

        void GetMaster(ObservableCollection<EducationDocumentBase> education);
        void GetMaster(EducationDocumentBase education);

        void GetSpecialty(ObservableCollection<EducationDocumentBase> education);
        void GetSpecialty(EducationDocumentBase education);

        void GetUserControlEducation(UserControl userControl, EducationDocumentBase document);
    }
}