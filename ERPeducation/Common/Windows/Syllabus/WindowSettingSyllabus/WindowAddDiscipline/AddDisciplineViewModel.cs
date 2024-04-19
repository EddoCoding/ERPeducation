using ERPeducation.ViewModels.Modules.TrainingDivision;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.Common.Windows.Syllabus.WindowSettingSyllabus.WindowAddDiscipline
{
    public class AddDisciplineViewModel : ReactiveObject
    {
        public DisciplineVM DisciplineVM { get; set; } = new();

        ObservableCollection<DisciplineVM> _disciplines;

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<DisciplineVM, Unit> AddDisciplineCommand { get; set; }

        Action closeWindow;

        IDiscipline _IDiscipline;
        public AddDisciplineViewModel(ObservableCollection<DisciplineVM> disciplines, Action closeWindow) 
        {
            _disciplines = disciplines;
            this.closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddDisciplineCommand = ReactiveCommand.Create<DisciplineVM>(AddDiscipline);
        }

        void Exit() => closeWindow();
        void AddDiscipline(DisciplineVM discipline)
        {
            _disciplines.Add(new DisciplineVM()
            {
                TitleSubject = discipline.TitleSubject,
                LectureHours = discipline.LectureHours,
                PracticeHours = discipline.PracticeHours,
                TypeOfControl = discipline.TypeOfControl
            });

            closeWindow();
        }
    }
}