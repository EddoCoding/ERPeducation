using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.DeanRoom.StudentVM
{
    public class EditStudentViewModel
    {
        public Student OldStudent { get; set; }
        public Student NewStudent { get; set; }

        Faculty _selectedFaculty;
        LvlOfTraining _selectedLevel;
        FormsOfTraining _selectedForm;
        TypeGroup _selectedTypeGroup;
        Group _selectedGroup;

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Student, Unit> EditStudentCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public EditStudentViewModel(IDeanRoomRepository repository, Student student, Group group, TypeGroup selectedTypeGroup,
            FormsOfTraining selectedForm, LvlOfTraining selectedLevel, Faculty selectedFaculty, Action closeWindow)
        {
            _repository = repository;
            OldStudent = student;
            _selectedForm = selectedForm;
            _selectedLevel = selectedLevel;
            _selectedFaculty = selectedFaculty;
            _selectedTypeGroup = selectedTypeGroup;
            _selectedGroup = group;
            _closeWindow = closeWindow;

            NewStudent = new Student();

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            EditStudentCommand = ReactiveCommand.Create<Student>(EditStudent);
        }

        void Exit() => _closeWindow();
        void EditStudent(Student student)
        {
            //Пока менять нечего внутри студента, поэтому -- не добавляю --
            NewStudent.FullName = $"{NewStudent.SurName} {NewStudent.Name} {NewStudent.MiddleName}";
            student.FullName = $"{student.SurName} {student.Name} {student.MiddleName}";
            _repository.EditStudent(student, NewStudent, _selectedGroup, _selectedTypeGroup, _selectedForm, _selectedLevel, _selectedFaculty);
            _closeWindow();
        }
    }
}
