using ERPeducation.Models;
using ERPeducation.Models.TrainingDivision;
using ERPeducation.ViewModels.Modules.TrainingDivision.Repository;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.ScheduleVM
{
    public class CreateScheduleViewModel : ReactiveObject
    {
        public ScheduleVM Schedule { get; set; } = new();
        public ObservableCollection<Syllabus> Syllabus { get; set; }
        [Reactive] public Syllabus SelectedSyllabus { get; set; }

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<ScheduleVM, Unit> CreateScheduleCommand { get; set; }

        Action _closeWindow;

        IScheduleRepository _repository;
        public CreateScheduleViewModel(IScheduleRepository repository, ObservableCollection<Syllabus> syllabus, Action closeWindow)
        {
            _repository = repository;
            Syllabus = syllabus;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            CreateScheduleCommand = ReactiveCommand.Create<ScheduleVM>(CreateSchedule);
        }

        void Exit() => _closeWindow();
        void CreateSchedule(ScheduleVM schedule)
        {
            _repository.AddSchedule(new Schedule()
            {
                TitleSchedule = schedule.TitleSchedule,
                Syllabus = SelectedSyllabus
            });
            _closeWindow();
        }
    }
}