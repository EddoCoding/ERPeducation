using ERPeducation.Models;
using ERPeducation.Models.AdmissionCampaign;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public interface IAdmissionRepository
    {
        ICollection<Enrollee> Enrollees { get; set; }
        ICollection<Enrollee> GetEnrollees();
        void OpenPageAddEnrollee(MainTabControl<MainTabItem> mainTabControls, ObservableCollection<Enrollee> enrollees);
        void CreateEnrollee();
    }
}