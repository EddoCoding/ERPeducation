using ERPeducation.Models;
using ERPeducation.Models.AdmissionCampaign;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class AdmissionCampaignViewModel : ReactiveObject
    {
        MainTabControl<MainTabItem> _mainTabControls;
        ObservableCollection<Enrollee> _enrollees;
        public ObservableCollection<Enrollee> Enrollees
        {
            get => _enrollees;
            set
            {
                _enrollees = value;
                this.RaiseAndSetIfChanged(ref _enrollees, value);
            }
        }





        IAdmissionRepository _dataRepository;
        public AdmissionCampaignViewModel(IAdmissionRepository dataRepository, MainTabControl<MainTabItem> mainTabControls)
        {
            _dataRepository = dataRepository;
            this._mainTabControls = mainTabControls;

            LoadDataEnrollees();
        }

        void LoadDataEnrollees() => Enrollees = new ObservableCollection<Enrollee>(_dataRepository.GetEnrollees());

    }
}