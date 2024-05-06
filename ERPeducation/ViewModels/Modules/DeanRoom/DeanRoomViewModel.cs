﻿using ERPeducation.Models.DeanRoom;
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
            set
            {
                this.RaiseAndSetIfChanged(ref _faculty, value);
                if(_faculty != null)
                {
                    Lvl.Clear();
                    Forms.Clear();
                    TypeGroups.Clear();
                    Groups.Clear();
                    Students.Clear();
                    _repository.SelectedFaculty(_faculty);
                }
            }
        }

        LvlOfTraining _level;
        public LvlOfTraining Level
        {
            get => _level;
            set
            {
                this.RaiseAndSetIfChanged(ref _level, value);
                if(_level != null)
                {
                    Forms.Clear();
                    TypeGroups.Clear();
                    Groups.Clear();
                    Students.Clear();
                    _repository.SelectedLevel(_level);
                }
            }
        }

        FormsOfTraining _form;
        public FormsOfTraining Form
        {
            get => _form;
            set
            {
                this.RaiseAndSetIfChanged(ref _form, value);
                if(_form != null)
                {
                    TypeGroups.Clear();
                    Groups.Clear();
                    Students.Clear();
                    _repository.SelectedForm(_form);
                }
            }
        }

        TypeGroup _typeGroup;
        public TypeGroup TypeGroup
        {
            get => _typeGroup;
            set
            {
                this.RaiseAndSetIfChanged(ref _typeGroup, value);
                if(_typeGroup != null)
                {
                    Groups.Clear();
                    Students.Clear();
                    _repository.SelectedTypeGroup(_typeGroup);
                }
            }
        }

        Group _group;
        public Group Group
        {
            get => _group;
            set
            {
                this.RaiseAndSetIfChanged(ref _group, value);
                if(_group != null)
                {
                    Students.Clear();
                    _repository.SelectedGroup(_group);
                }
            }
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
        #region Команды изменения
        public ReactiveCommand<Faculty,Unit> EditFacultyCommand { get; set; }
        public ReactiveCommand<LvlOfTraining,Unit> EditLevelCommand { get; set; }
        public ReactiveCommand<FormsOfTraining,Unit> EditFormCommand { get; set; }
        public ReactiveCommand<TypeGroup,Unit> EditTypeGroupCommand { get; set; }
        public ReactiveCommand<Group,Unit> EditGroupCommand { get; set; }
        public ReactiveCommand<Student,Unit> EditStudentCommand { get; set; }
        #endregion
        #region Команды удаления
        public ReactiveCommand<Faculty, Unit> DelFacultyCommand { get; set; }
        public ReactiveCommand<LvlOfTraining, Unit> DelLevelCommand { get; set; }
        public ReactiveCommand<FormsOfTraining, Unit> DelFormCommand { get; set; }
        public ReactiveCommand<TypeGroup, Unit> DelTypeGroupCommand { get; set; }
        public ReactiveCommand<Group, Unit> DelGroupCommand { get; set; }
        public ReactiveCommand<Student, Unit> DelStudentCommand { get; set; }
        #endregion

        IDeanRoomService _deanRoomService;
        IDeanRoomRepository _repository;

        public DeanRoomViewModel(IDeanRoomService deanRoomService, IDeanRoomRepository deanRoomRepository)
        {
            _deanRoomService = deanRoomService;
            _repository = deanRoomRepository;

            Faculties = new ObservableCollection<Faculty>();
            foreach (var faculty in _repository.GetJsonFaculty())
                Faculties.Add(faculty);

            #region Коллекции
            Lvl = new ObservableCollection<LvlOfTraining>();
            Forms = new ObservableCollection<FormsOfTraining>();
            TypeGroups = new ObservableCollection<TypeGroup>();
            Groups = new ObservableCollection<Group>();
            Students = new ObservableCollection<Student>();
            #endregion
            #region Синхронизация через подписку на изменеия коллекций в репозитории
            _repository.Faculties.CollectionChanged += (sender,e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Faculties.Add(e.NewItems[0] as Faculty);
                else if(e.Action == NotifyCollectionChangedAction.Remove) Faculties.Remove(e.OldItems[0] as Faculty);
            };
            _repository.Levels.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Lvl.Add(e.NewItems[0] as LvlOfTraining);
                else if (e.Action == NotifyCollectionChangedAction.Remove) Lvl.Remove(e.OldItems[0] as LvlOfTraining);
            };
            _repository.Forms.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Forms.Add(e.NewItems[0] as FormsOfTraining);
                else if (e.Action == NotifyCollectionChangedAction.Remove) Forms.Remove(e.OldItems[0] as FormsOfTraining);
            };
            _repository.Types.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) TypeGroups.Add(e.NewItems[0] as TypeGroup);
                else if (e.Action == NotifyCollectionChangedAction.Remove) TypeGroups.Remove(e.OldItems[0] as TypeGroup);
            };
            _repository.Groups.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Groups.Add(e.NewItems[0] as Group);
                else if (e.Action == NotifyCollectionChangedAction.Remove) Groups.Remove(e.OldItems[0] as Group);
            };
            _repository.Students.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Students.Add(e.NewItems[0] as Student);
                else if (e.Action == NotifyCollectionChangedAction.Remove) Students.Remove(e.OldItems[0] as Student);
            };
            #endregion
            #region Инициализация команд добавления
            AddFacultyCommand = ReactiveCommand.Create(AddFaculty);
            AddLvlCommand = ReactiveCommand.Create(AddLevel);
            AddFormCommand = ReactiveCommand.Create(AddForm);
            AddTypeGroupCommand = ReactiveCommand.Create(AddTypeGroup);
            AddGroupCommand = ReactiveCommand.Create(AddGroup);
            AddStudentCommand = ReactiveCommand.Create(AddStudent);
            #endregion
            #region Команды изменения
            EditFacultyCommand = ReactiveCommand.Create<Faculty>(editFaculty);
            EditLevelCommand = ReactiveCommand.Create<LvlOfTraining>(editLevel);
            EditFormCommand = ReactiveCommand.Create<FormsOfTraining>(editForm);
            EditTypeGroupCommand = ReactiveCommand.Create<TypeGroup>(editTypeGroup);
            EditGroupCommand = ReactiveCommand.Create<Group>(editGroup);
            EditStudentCommand = ReactiveCommand.Create<Student>(editStudent);
            #endregion
            #region Инициализация команд удаления
            DelFacultyCommand = ReactiveCommand.Create<Faculty>(DelFaculty);
            DelLevelCommand = ReactiveCommand.Create<LvlOfTraining>(DelLevel);
            DelFormCommand = ReactiveCommand.Create<FormsOfTraining>(DelForm);
            DelTypeGroupCommand = ReactiveCommand.Create<TypeGroup>(DelTypeGroup);
            DelGroupCommand = ReactiveCommand.Create<Group>(DelGroup);
            DelStudentCommand = ReactiveCommand.Create<Student>(DelStudent);
            #endregion
        }

        #region Методы добавления
        void AddFaculty() => _deanRoomService.OpenWindowCreateFaculty(_repository);
        void AddLevel()
        {
            if (_faculty != null) _deanRoomService.OpenWindowCreateLevel(_repository, _faculty);

        }
        void AddForm()
        {
            if (_level != null) _deanRoomService.OpenWindowCreateForm(_repository, _level, _faculty);
        }
        void AddTypeGroup()
        {
            if (_form != null) _deanRoomService.OpenWindowCreateTypeGroup(_repository, _form, _level, _faculty);
        }
        void AddGroup()
        {
            if (_typeGroup != null) _deanRoomService.OpenWindowCreateGroup(_repository, _typeGroup, _form, _level, _faculty);
        }
        void AddStudent()
        {
            if (_group != null) _deanRoomService.OpenWindowCreateStudent(_repository, _group, _typeGroup, _form, _level, _faculty);
        }
        #endregion
        #region Методы изменения
        void editFaculty(Faculty faculty) => _deanRoomService.OpenWindowEditFaculty(_repository, faculty);
        void editLevel(LvlOfTraining level) => _deanRoomService.OpenWindowEditLevel(_repository, level, _faculty);
        void editForm(FormsOfTraining form) => _deanRoomService.OpenWindowEditForm(_repository, form, _level, _faculty);
        void editTypeGroup(TypeGroup typeGroup) => _deanRoomService.OpenWindowEditTypeGroup(_repository, typeGroup, _form, _level, _faculty);
        void editGroup(Group group) => _deanRoomService.OpenWindowEditGroup(_repository, group, _typeGroup, _form, _level, _faculty);
        void editStudent(Student student) => _deanRoomService.OpenWindowEditStudent(_repository, student, _group, _typeGroup, _form, _level, _faculty);
        #endregion
        #region Методы удаления
        void DelFaculty(Faculty faculty) => _repository.DeleteFaculty(faculty);
        void DelLevel(LvlOfTraining level) => _repository.DeleteLevel(level, _faculty);
        void DelForm(FormsOfTraining form) => _repository.DeleteForm(form, _level, _faculty);
        void DelTypeGroup(TypeGroup typeGroup) => _repository.DeleteTypeGroup(typeGroup, _form, _level, _faculty);
        void DelGroup(Group group) => _repository.DeleteGroup(group, _typeGroup, _form, _level, _faculty);
        void DelStudent(Student student) => _repository.DeleteStudent(student, _group, _typeGroup, _form, _level, _faculty);
        #endregion
    }
}