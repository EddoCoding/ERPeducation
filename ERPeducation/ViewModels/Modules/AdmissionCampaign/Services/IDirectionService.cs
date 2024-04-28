using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Services
{
    public interface IDirectionService
    {
        ObservableCollection<string> Directions { get; set; }

        void GetDirections();
    }
}
