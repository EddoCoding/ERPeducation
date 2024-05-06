using ERPeducation.Models;
using ERPeducation.Models.AdmissionCampaign;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public interface IAdmissionRepository
    {
        ObservableCollection<Enrollee> Enrollees { get; set; }
        void GetEnrollees();
        void CreateEnrollee(Enrollee enrollee);
        void DelEnrolle(Enrollee enrollee);
        void OpenPageAddEnrollee(MainTabControl<MainTabItem> mainTabControls);

        void OpenWindowInputResultTest();
    }
}