using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System.Reactive;
using System;
using System.Security.Cryptography;

namespace ERPeducation.ViewModels.Modules.DeanRoom.StudentVM
{
    public class EditStudentViewModel
    {
        public Student OldStudent { get; set; }
        public Student NewStudent { get; set; } = new Student();

        public Faculty SelectedFaculty { get; set; }
        public LvlOfTraining SelectedLevel { get; set; }
        public FormsOfTraining SelectedForm { get; set; }
        public TypeGroup SelectedTypeGroup { get; set; }
        public Group SelectedGroup { get; set; }

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Student, Unit> EditStudentCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public EditStudentViewModel(IDeanRoomRepository repository, Student student, Group group, TypeGroup selectedTypeGroup,
            FormsOfTraining selectedForm, LvlOfTraining selectedLevel, Faculty selectedFaculty, Action closeWindow)
        {
            _repository = repository;
            OldStudent = student;
            SelectedForm = selectedForm;
            SelectedLevel = selectedLevel;
            SelectedFaculty = selectedFaculty;
            SelectedTypeGroup = selectedTypeGroup;
            SelectedGroup = group;
            _closeWindow = closeWindow;

            NewStudent.SurName = student.SurName;
            NewStudent.Name = student.Name;
            NewStudent.MiddleName = student.MiddleName;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            EditStudentCommand = ReactiveCommand.Create<Student>(EditStudent);
        }

        void Exit() => _closeWindow();
        void EditStudent(Student student)
        {
            if (NewStudent.SurName == OldStudent.SurName && NewStudent.Name == OldStudent.Name && NewStudent.MiddleName == OldStudent.MiddleName)
            {
                _closeWindow();
                return;
            }

            NewStudent.FullName = $"{NewStudent.SurName} {NewStudent.Name} {NewStudent.MiddleName}";
            student.FullName = $"{student.SurName} {student.Name} {student.MiddleName}";
            NewStudent.TitleFaculty = SelectedFaculty.NameFaculty;
            NewStudent.TitleLevel = SelectedLevel.NameLevel;
            NewStudent.TitleForm = SelectedForm.NameForm;
            NewStudent.TitleTypeGroup = SelectedTypeGroup.NameType;
            NewStudent.TitleGroup = SelectedGroup.NameGroup;
            NewStudent.TitleDirection = SelectedGroup.Direction;
            _repository.EditStudent(student, NewStudent, SelectedGroup, SelectedTypeGroup, SelectedForm, SelectedLevel, SelectedFaculty);
            _closeWindow();
        }
    }
}
