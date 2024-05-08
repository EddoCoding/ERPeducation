using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.Models.DeanRoom;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Repository
{
    public interface IEnrolleeGroupService
    {
        ObservableCollection<Enrollee> Enrollees { get; set; }
        void GetEnrollees(Group group);
    }
}