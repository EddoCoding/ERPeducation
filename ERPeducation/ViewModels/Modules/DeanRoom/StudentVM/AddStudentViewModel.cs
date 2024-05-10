using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom.StudentVM
{
    public class AddStudentViewModel
    {
        public Student Student { get; set; } = new();

        public Faculty SelectedFaculty { get; set; }
        public LvlOfTraining SelectedLevel {get; set;}
        public FormsOfTraining SelectedForm {get; set;}
        public TypeGroup SelectedTypeGroup {get; set;}
        public Group SelectedGroup {get; set;}

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Student, Unit> AddStudentCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public AddStudentViewModel(IDeanRoomRepository repository, Group group, TypeGroup selectedTypeGroup, 
            FormsOfTraining selectedForm, LvlOfTraining selectedLevel, Faculty selectedFaculty, Action closeWindow)
        {
            _repository = repository;
            SelectedForm = selectedForm;
            SelectedLevel = selectedLevel;
            SelectedFaculty = selectedFaculty;
            SelectedTypeGroup = selectedTypeGroup;
            SelectedGroup = group;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddStudentCommand = ReactiveCommand.Create<Student>(AddStudent);
        }

        void Exit() => _closeWindow();
        void AddStudent(Student student)
        {
            student.FullName = $"{student.SurName} {student.Name} {student.MiddleName}";
            student.TitleFaculty = SelectedFaculty.NameFaculty;
            student.TitleLevel = SelectedLevel.NameLevel;
            student.TitleForm = SelectedForm.NameForm;
            student.TitleTypeGroup = SelectedTypeGroup.NameType;
            student.TitleGroup = SelectedGroup.NameGroup;
            student.TitleDirection = SelectedGroup.Direction;
            _repository.CreateStudent(student, SelectedGroup, SelectedTypeGroup, SelectedForm, SelectedLevel, SelectedFaculty);
            _closeWindow();
        }
    }
}
