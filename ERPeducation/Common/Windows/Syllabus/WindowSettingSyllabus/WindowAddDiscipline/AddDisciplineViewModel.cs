using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.Common.Windows.Syllabus.WindowSettingSyllabus.WindowAddDiscipline
{
    public class AddDisciplineViewModel : ReactiveObject
    {
        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AddDisciplineCommand { get; set; }

        Action closeWindow;

        public AddDisciplineViewModel(Action closeWindow) 
        {
            this.closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddDisciplineCommand = ReactiveCommand.Create(AddDiscipline);
        }

        void Exit() => closeWindow();
        void AddDiscipline()
        {
            closeWindow();
        }
    }
}