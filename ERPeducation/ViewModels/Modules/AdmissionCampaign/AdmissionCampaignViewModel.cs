using ERPeducation.Models;
using ERPeducation.Models.AdmissionCampaign;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive;
using System.Windows;

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

        [Reactive] public Enrollee SelectedEnrollee { get; set; }// = new Enrollee();

        public ReactiveCommand<Unit,Unit> OpenPageAddEnrolleeCommand { get; set; }
        public ReactiveCommand<Enrollee, Unit> DelEnrolleeCommand { get; set; }
        public ReactiveCommand<Enrollee, Unit> InputDataTestCommand { get; set; }
        public ReactiveCommand<Unit,Unit> PrintDocumentCommand { get; set; }

        IAdmissionRepository _repository;
        public AdmissionCampaignViewModel(IAdmissionRepository repository, MainTabControl<MainTabItem> mainTabControls)
        {
            _repository = repository;
            _mainTabControls = mainTabControls;

            Enrollees = new ObservableCollection<Enrollee>();
            repository.Enrollees.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) _enrollees.Add(e.NewItems[0] as Enrollee);
                else if (e.Action == NotifyCollectionChangedAction.Remove) _enrollees.Remove(e.OldItems[0] as Enrollee);
            };

            repository.GetEnrollees();

            OpenPageAddEnrolleeCommand = ReactiveCommand.Create(OpenPageAddEnrollee);
            DelEnrolleeCommand = ReactiveCommand.Create<Enrollee>(DelEnrollee);
            InputDataTestCommand = ReactiveCommand.Create<Enrollee>(InputDataTest);
            PrintDocumentCommand = ReactiveCommand.Create(PrintDocument);
        }

        void OpenPageAddEnrollee() => _repository.OpenPageAddEnrollee(_mainTabControls);
        void DelEnrollee(Enrollee enrollee) => _repository.DelEnrolle(enrollee);
        void InputDataTest(Enrollee enrollee)
        {
            if(SelectedEnrollee != null) MessageBox.Show($"{enrollee.SurName}{enrollee.SurName}{enrollee.MiddleName}");
        }
        void PrintDocument() => NotReady.Message();
    }
}