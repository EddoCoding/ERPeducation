using ERPeducation.Models.AdmissionCampaign.Direction;
using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Repositories;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions
{
    public class DirectionViewModel : ReactiveObject
    {
        public DirectionOfAdmission Direction { get; set; } = new();

        #region Коллекции данных
        public ObservableCollection<Faculty> Faculties { get; set; }
        public ObservableCollection<LvlOfTraining> Levels { get; set; }
        public ObservableCollection<FormsOfTraining> Forms { get; set; }
        public ObservableCollection<TypeGroup> Types { get; set; }
        public ObservableCollection<Group> GroupDirections { get; set; }
        public ObservableCollection<string> test { get; set; }
        #endregion
        #region Свойства выбранных элементов
        Faculty _selectedFaculty;
        public Faculty SelectedFaculty
        {
            get => _selectedFaculty;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedFaculty, value);
                if(_selectedFaculty != null)
                {
                    Levels.Clear();
                    Forms.Clear();
                    Types.Clear();
                    GroupDirections.Clear();
                    _directionRepository.GetLevels(_selectedFaculty);
                }
            }
        }

        LvlOfTraining _selectedLevel;
        public LvlOfTraining SelectedLevel
        {
            get => _selectedLevel;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedLevel, value);
                if(_selectedLevel != null)
                {
                    Forms.Clear();
                    Types.Clear();
                    GroupDirections.Clear();
                    _directionRepository.GetForms(_selectedLevel);
                }
            }
        }

        FormsOfTraining _selectedForm;
        public FormsOfTraining SelectedForm
        {
            get => _selectedForm;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedForm, value);
                if(_selectedForm != null)
                {
                    Types.Clear();
                    GroupDirections.Clear();
                    _directionRepository.GetTypes(_selectedForm);
                }
            }
        }

        TypeGroup _selectedType;
        public TypeGroup SelectedType
        {
            get => _selectedType;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedType, value);
                if(_selectedType != null)
                {
                    GroupDirections.Clear();
                    _directionRepository.GetGroups(_selectedType);
                }
            }
        }

        [Reactive] public Group SelectedGroup { get; set; }
        #endregion

        Action _closeWindow;

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<DirectionOfAdmission, Unit> AddDirectionCommand { get; set; }

        IDirectionRepository _directionRepository;
        IEnrolleeRepository _repository;
        public DirectionViewModel(IEnrolleeRepository repository, Action closeWindow)
        {
            _repository = repository;
            _closeWindow = closeWindow;
            _directionRepository = new DirectionRepository();

            Faculties = new ObservableCollection<Faculty>();
            Levels = new ObservableCollection<LvlOfTraining>();
            Forms = new ObservableCollection<FormsOfTraining>();
            Types = new ObservableCollection<TypeGroup>();
            GroupDirections = new ObservableCollection<Group>();
            test = new ObservableCollection<string>();

            #region Синхронизация
            _directionRepository.Faculties.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Faculties.Add(e.NewItems[0] as Faculty);
            };
            _directionRepository.Levels.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Levels.Add(e.NewItems[0] as LvlOfTraining);
            };
            _directionRepository.Forms.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Forms.Add(e.NewItems[0] as FormsOfTraining);
            };
            _directionRepository.Types.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Types.Add(e.NewItems[0] as TypeGroup);
            };
            _directionRepository.Groups.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) GroupDirections.Add(e.NewItems[0] as Group);
            };
            #endregion

            _directionRepository.GetFaculties();

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddDirectionCommand = ReactiveCommand.Create<DirectionOfAdmission>(AddDirection);
        }

        void Exit() => _closeWindow();
        void AddDirection(DirectionOfAdmission direction)
        {
            direction.NameFaculty = SelectedFaculty.NameFaculty;
            direction.NameLevel = SelectedLevel.NameLevel;
            direction.NameForm = SelectedForm.NameForm;
            direction.NameType = SelectedType.NameType;
            direction.NameDirection = SelectedGroup.Direction;

            _repository.CreateDirection(direction);
            _closeWindow();
        }
    }
}
