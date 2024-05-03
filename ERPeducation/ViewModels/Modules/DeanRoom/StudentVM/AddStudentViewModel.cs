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

        Faculty _selectedFaculty;
        LvlOfTraining _selectedLevel;
        FormsOfTraining _selectedForm;
        TypeGroup _selectedTypeGroup;
        Group _selectedGroup;

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Student, Unit> AddStudentCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public AddStudentViewModel(IDeanRoomRepository repository, Group group, TypeGroup selectedTypeGroup, 
            FormsOfTraining selectedForm, LvlOfTraining selectedLevel, Faculty selectedFaculty, Action closeWindow)
        {
            _repository = repository;
            _selectedForm = selectedForm;
            _selectedLevel = selectedLevel;
            _selectedFaculty = selectedFaculty;
            _selectedTypeGroup = selectedTypeGroup;
            _selectedGroup = group;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddStudentCommand = ReactiveCommand.Create<Student>(AddStudent);
        }

        void Exit() => _closeWindow();
        void AddStudent(Student student)
        {
            student.FullName = $"{student.SurName} {student.Name} {student.MiddleName}"; // -- Здесь формируется полное ФИО --
            _repository.CreateStudent(student, _selectedGroup, _selectedTypeGroup, _selectedForm, _selectedLevel, _selectedFaculty);
            _closeWindow();
        }
    }
}
