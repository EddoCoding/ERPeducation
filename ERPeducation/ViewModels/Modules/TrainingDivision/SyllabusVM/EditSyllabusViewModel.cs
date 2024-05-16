using ERPeducation.Models;
using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.TrainingDivision.Repository;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.SyllabusVM
{
    public class EditSyllabusViewModel
    {
        public Syllabus OldSyllabus { get; set; }
        public Syllabus NewSyllabus { get; set; } = new();

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Syllabus, Unit> EditSyllabusCommand { get; set; }

        Action _closeWindow;

        ISyllabusRepository _syllabusRepository;
        public EditSyllabusViewModel(ISyllabusRepository syllabusRepository, Syllabus syllabus, Action closeWindow)
        {
            _syllabusRepository = syllabusRepository;
            OldSyllabus = syllabus;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            EditSyllabusCommand = ReactiveCommand.Create<Syllabus>(EditSyllabus);
        }

        void Exit() => _closeWindow();
        void EditSyllabus(Syllabus syllabus)
        {
            NewSyllabus.Semesters = syllabus.Semesters;
            _syllabusRepository.EditSyllabus(syllabus, NewSyllabus);
            _closeWindow();
        }
    }
}
