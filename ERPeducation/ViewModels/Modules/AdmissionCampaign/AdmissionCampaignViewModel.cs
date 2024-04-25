using ERPeducation.Models;
using ERPeducation.Models.AdmissionCampaign;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class AdmissionCampaignViewModel : ReactiveObject
    {
        MainTabControl<MainTabItem> _mainTabControls;
        ObservableCollection<Enrollee> _enrollees;
        public ObservableCollection<Enrollee> Enrollees
        {
            get => _enrollees;
            set => this.RaiseAndSetIfChanged(ref _enrollees, value);
        }


        public ReactiveCommand<Unit,Unit> OpenPageAddEnrolleeCommand { get; set; }


        IAdmissionRepository _dataRepository;
        public AdmissionCampaignViewModel(IAdmissionRepository dataRepository, MainTabControl<MainTabItem> mainTabControls)
        {
            _dataRepository = dataRepository;
            this._mainTabControls = mainTabControls;

            LoadDataEnrollees();

            OpenPageAddEnrolleeCommand = ReactiveCommand.Create(OpenPageAddEnrollee);
        }

        void LoadDataEnrollees() => Enrollees = new ObservableCollection<Enrollee>(_dataRepository.GetEnrollees());
        void OpenPageAddEnrollee() => _dataRepository.OpenPageAddEnrollee(_mainTabControls, Enrollees);
    }
}