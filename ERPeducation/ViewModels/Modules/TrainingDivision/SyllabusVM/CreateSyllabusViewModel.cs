using ERPeducation.Models;
using ERPeducation.ViewModels.Modules.TrainingDivision.Service;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.SyllabusVM
{
    public class CreateSyllabusViewModel
    {
        public Syllabus Syllabus { get; set; } = new();

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Syllabus, Unit> CreateSyllabusCommand { get; set; }

        Action _closeWindow;

        ISyllabusRepository _syllabusRepository;
        public CreateSyllabusViewModel(ISyllabusRepository syllabusRepository, Action closeWindow)
        {
            _syllabusRepository = syllabusRepository;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            CreateSyllabusCommand = ReactiveCommand.Create<Syllabus>(CreateSyllabus);
        }

        void Exit() => _closeWindow();
        void CreateSyllabus(Syllabus syllabus)
        {
            _syllabusRepository.CreateSyllabus(syllabus);
            _closeWindow();
        }
    }
}