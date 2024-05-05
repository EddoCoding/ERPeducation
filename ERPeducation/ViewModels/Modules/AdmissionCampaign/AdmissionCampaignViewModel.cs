using ERPeducation.Models;
using ERPeducation.Models.AdmissionCampaign;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
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

        [Reactive] public Enrollee SelectedEnrollee { get; set; } = new Enrollee();

        public ReactiveCommand<Unit,Unit> OpenPageAddEnrolleeCommand { get; set; }

        IAdmissionRepository _repository;
        public AdmissionCampaignViewModel(IAdmissionRepository repository, MainTabControl<MainTabItem> mainTabControls)
        {
            _repository = repository;
            _mainTabControls = mainTabControls;

            Enrollees = new ObservableCollection<Enrollee>();
            foreach (var enrollee in repository.GetEnrollees())
                _enrollees.Add(enrollee);

            OpenPageAddEnrolleeCommand = ReactiveCommand.Create(OpenPageAddEnrollee);
        }

        void OpenPageAddEnrollee() => _repository.OpenPageAddEnrollee(_mainTabControls, _enrollees);
    }
}