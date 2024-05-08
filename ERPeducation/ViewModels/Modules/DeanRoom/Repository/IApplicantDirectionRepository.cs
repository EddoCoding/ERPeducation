using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.Models.DeanRoom;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Repository
{
    public interface IApplicantDirectionRepository
    {
        ObservableCollection<string> Directions { get; set; }
        ObservableCollection<Enrollee> DirectionEnrollees { get; set; }
        void GetDirections();
        void GetEnrollees(string direction);
    }
}