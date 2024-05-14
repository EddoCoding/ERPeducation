using ERPeducation.Models;
using ERPeducation.Models.DeanRoom;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.SyllabusVM
{
    public class ShowSyllabusViewModel : ReactiveObject
    {
        public Syllabus Syllabus { get; set; }
        public ObservableCollection<Semestr> Semesters { get; set; } = new();
        public Group Group { get; set; }

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }

        Action _closeWindow;

        public ShowSyllabusViewModel(Syllabus syllabus, Group group, Action closeWindow)
        {
            Syllabus = syllabus;
            Semesters = syllabus.Semesters;
            Group = group;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
        }

        void Exit() => _closeWindow();
    }
}