using ERPeducation.Models;
using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.Models.AdmissionCampaign.Direction;
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

        [Reactive] public Enrollee SelectedEnrollee { get; set; }
        public DirectionOfAdmission SelectedDirection { get; set; }

        #region Команды
        public ReactiveCommand<Unit,Unit> OpenPageAddEnrolleeCommand { get; set; }
        public ReactiveCommand<Enrollee, Unit> EditEnrolleeCommand { get; set; }
        public ReactiveCommand<Enrollee, Unit> DelEnrolleeCommand { get; set; }
        public ReactiveCommand<Enrollee, Unit> InputDataTestCommand { get; set; }
        public ReactiveCommand<Unit,Unit> PrintDocumentCommand { get; set; } //Сделать потом
        #endregion

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

            #region Инициализация команд
            OpenPageAddEnrolleeCommand = ReactiveCommand.Create(OpenPageAddEnrollee);
            EditEnrolleeCommand = ReactiveCommand.Create<Enrollee>(EditEnrollee);
            DelEnrolleeCommand = ReactiveCommand.Create<Enrollee>(DelEnrollee);
            InputDataTestCommand = ReactiveCommand.Create<Enrollee>(InputDataTest);
            PrintDocumentCommand = ReactiveCommand.Create(PrintDocument);
            #endregion
        }
        
        #region Методы команд
        void OpenPageAddEnrollee() => _repository.OpenPageAddEnrollee(_mainTabControls);
        void EditEnrollee(Enrollee enrollee) => _repository.OpenPageEditEnrollee(_mainTabControls, enrollee);
        void DelEnrollee(Enrollee enrollee) => _repository.DelEnrolle(enrollee);
        void InputDataTest(Enrollee enrollee)
        {
            if(SelectedDirection != null) _repository.OpenWindowInputResultTest(SelectedDirection, SelectedEnrollee);
        }
        void PrintDocument() => NotReady.Message();
        #endregion
    }
}