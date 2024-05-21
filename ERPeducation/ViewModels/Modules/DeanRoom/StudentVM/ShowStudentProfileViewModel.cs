using ERPeducation.Models.DeanRoom;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom.StudentVM
{
    public class ShowStudentProfileViewModel
    {
        public Student Student { get; set; }

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }

        Action _closeWindow;

        public ShowStudentProfileViewModel(Student student, Action closeWindow)
        {
            Student = student;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
        }

        void Exit() => _closeWindow();
    }
}