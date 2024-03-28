using ERPeducation.Common.Interface;
using ERPeducation.Models;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.Common.Windows.WindowEducation
{
    public interface IDialogEducation
    {
        void GetBasicGeneral(ObservableCollection<EducationDocumentBase> education);
        void GetBasicGeneral(BasicGeneralEducationViewModel education);

        void GetBasicAverage(ObservableCollection<EducationDocumentBase> education);
        void GetBasicAverage(BasicAverageEducationViewModel education);

        void GetSpo(ObservableCollection<EducationDocumentBase> education);
        void GetSpo(EducationSpoViewModel education);

        void GetUndergraduate(ObservableCollection<EducationDocumentBase> education);
        void GetUndergraduate(EducationUndergraduateViewModel education);

        void GetMaster(ObservableCollection<EducationDocumentBase> education);
        void GetMaster(EducationMasterViewModel education);

        void GetSpecialty(ObservableCollection<EducationDocumentBase> education);
        void GetSpecialty(EducationSpecialtyViewModel education);

        void GetUserControlEducation(UserControl userControl, EducationDocumentBase document);
    }
}