using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ERPeducation.ViewModels.Modules.DeanRoom.Service;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom
{
    public class DeanRoomViewModel : ReactiveObject
    {
        #region Коллекции
        public ObservableCollection<Faculty>? Faculties { get; set; }               // -- Факультеты --
        public ObservableCollection<LvlOfTraining>? Lvl { get; set; }               // -- Уровни --
        public ObservableCollection<FormsOfTraining>? Forms { get; set; }           // -- Формы --
        public ObservableCollection<TypeGroup>? TypeGroups { get; set; }            // -- Тип групп --
        public ObservableCollection<Group>? Groups { get; set; }                    // -- Группы --
        public ObservableCollection<Student>? Students { get; set; }                // -- Студенты --
        #endregion
        #region Свойства выбранных элементов
        Faculty _faculty;
        public Faculty Faculty
        {
            get => _faculty;
            set => this.RaiseAndSetIfChanged(ref _faculty, value);
        }

        LvlOfTraining _level;
        public LvlOfTraining Level
        {
            get => _level;
            set => this.RaiseAndSetIfChanged(ref _level, value);
        }

        FormsOfTraining _form;
        public FormsOfTraining Form
        {
            get => _form;
            set => this.RaiseAndSetIfChanged(ref _form, value);
        }

        TypeGroup _typeGroup;
        public TypeGroup TypeGroup
        {
            get => _typeGroup;
            set => this.RaiseAndSetIfChanged(ref _typeGroup, value);
        }

        Group _group;
        public Group Group
        {
            get => _group;
            set => this.RaiseAndSetIfChanged(ref _group, value);
        }

        Student _student;
        public Student Student
        {
            get => _student;
            set => this.RaiseAndSetIfChanged(ref _student, value);
        }

        #endregion
        #region Команды добавления
        public ReactiveCommand<Unit,Unit> AddFacultyCommand { get; set; }
        public ReactiveCommand<Unit,Unit> AddLvlCommand { get; set; }
        public ReactiveCommand<Unit,Unit> AddFormCommand { get; set; }
        public ReactiveCommand<Unit,Unit> AddTypeGroupCommand { get; set; }
        public ReactiveCommand<Unit,Unit> AddGroupCommand { get; set; }
        public ReactiveCommand<Unit,Unit> AddStudentCommand { get; set; }
        #endregion
        #region Команды удаления
        public ReactiveCommand<Faculty, Unit> DelFacultyCommand { get; set; }
        #endregion

        IDeanRoomService _deanRoomService;
        IDeanRoomRepository _repository;

        public DeanRoomViewModel(IDeanRoomService deanRoomService, IDeanRoomRepository deanRoomRepository)
        {
            _deanRoomService = deanRoomService;
            _repository = deanRoomRepository;

            Faculties = new ObservableCollection<Faculty>();
            Lvl = new ObservableCollection<LvlOfTraining>();
            Forms = new ObservableCollection<FormsOfTraining>();
            TypeGroups = new ObservableCollection<TypeGroup>();
            Groups = new ObservableCollection<Group>();
            Students = new ObservableCollection<Student>();

            _repository.Faculties.CollectionChanged += (sender,e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Faculties.Add(e.NewItems[0] as Faculty);
                else if(e.Action == NotifyCollectionChangedAction.Remove) Faculties.Remove(e.OldItems[0] as Faculty);
            };

            #region Инициализация команд добавления
            AddFacultyCommand = ReactiveCommand.Create(AddFaculty);
            AddLvlCommand = ReactiveCommand.Create(AddLvl);
            AddFormCommand = ReactiveCommand.Create(AddForm);
            AddTypeGroupCommand = ReactiveCommand.Create(AddTypeGroup);
            AddGroupCommand = ReactiveCommand.Create(AddGroup);
            AddStudentCommand = ReactiveCommand.Create(AddStudent);
            #endregion
            #region Инициализация команд удаления
            DelFacultyCommand = ReactiveCommand.Create<Faculty>(DelFaculty);
            #endregion
        }

        #region Методы добавления
        void AddFaculty() => _deanRoomService.OpenWindowCreateFaculty(_repository);
        void AddLvl() => NotReady.Message();
        void AddForm() => NotReady.Message();
        void AddTypeGroup() => NotReady.Message();
        void AddGroup() => NotReady.Message();
        void AddStudent() => NotReady.Message();
        #endregion
        #region Методы удаления
        void DelFaculty(Faculty faculty) => _repository.DeleteFaculty(faculty);
        #endregion
    }
}
//if (e.Action == NotifyCollectionChangedAction.Add)
//    Enrollee.Documents.Add(e.NewItems[0] as DocumentBase);
//else if (e.Action == NotifyCollectionChangedAction.Remove)
//    Enrollee.Documents.Remove(e.OldItems[0] as DocumentBase);