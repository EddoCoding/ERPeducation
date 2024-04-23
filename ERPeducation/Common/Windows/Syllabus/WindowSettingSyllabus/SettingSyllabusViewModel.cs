using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.Common.Windows.Syllabus.WindowSettingSyllabus
{
    public class SettingSyllabusViewModel : ReactiveObject
    {
        public ReactiveCommand<Unit,Unit> AddSemestrCommand { get; set; }
        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        Action closeWindow;

        public SettingSyllabusViewModel(Action closeWindow)
        {
            this.closeWindow = closeWindow;
            AddSemestrCommand = ReactiveCommand.Create(AddSemestr);
            CloseWindowCommand = ReactiveCommand.Create(Exit);
        }

        void AddSemestr() { }
        void Exit() => closeWindow();
    }
}