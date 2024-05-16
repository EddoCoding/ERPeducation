using ERPeducation.Models;
using ERPeducation.Models.TrainingDivision;
using ERPeducation.ViewModels.Modules.TrainingDivision.Repository;
using ERPeducation.ViewModels.Modules.TrainingDivision.ScheduleVM;
using ERPeducation.ViewModels.Modules.TrainingDivision.Service;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class TrainingDivisionViewModel : ReactiveObject
    {
        public ObservableCollection<Syllabus> Syllabus { get; set; } = new();
        public ObservableCollection<Schedule> Schedules { get; set; } = new();

        #region Команды Учебного плана
        public ReactiveCommand<Unit,Unit> CreateSyllabusCommand { get; set; }
        public ReactiveCommand<Syllabus,Unit> EditSyllabusCommand { get; set; }
        public ReactiveCommand<Syllabus,Unit> SettingSyllabusCommand { get; set; }
        public ReactiveCommand<Syllabus,Unit> DelSyllabusCommand { get; set; }
        #endregion
        #region Команды Расписания
        public ReactiveCommand<Unit,Unit> CreateScheduleCommand { get; set; }
        public ReactiveCommand<Unit,Unit> EditScheduleCommand { get; set; }
        public ReactiveCommand<Schedule, Unit> SettingScheduleCommand { get; set; }
        public ReactiveCommand<Schedule, Unit> DelScheduleCommand { get; set; }
        #endregion

        IScheduleService _scheduleService = new ScheduleService();
        IScheduleRepository _scheduleRepository = new ScheduleRepository();
        ISyllabusService _syllabusService = new SyllabusService();
        ISyllabusRepository _syllabusRepository = new SyllabusRepository();
        public TrainingDivisionViewModel()
        {
            _syllabusRepository.Syllabus.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Syllabus.Add(e.NewItems[0] as Syllabus);
                else if (e.Action == NotifyCollectionChangedAction.Remove) Syllabus.Remove(e.OldItems[0] as Syllabus);
            };
            _syllabusRepository.GetSyllabus();

            _scheduleRepository.Schedules.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Schedules.Add(e.NewItems[0] as Schedule);
                else if (e.Action == NotifyCollectionChangedAction.Remove) Schedules.Remove(e.OldItems[0] as Schedule);
            };
            _scheduleRepository.GetSchedules();

            #region Команды
            CreateSyllabusCommand = ReactiveCommand.Create(createSyllabus);
            EditSyllabusCommand = ReactiveCommand.Create<Syllabus>(editSyllabus);
            SettingSyllabusCommand = ReactiveCommand.Create<Syllabus>(settingSyllabus);
            DelSyllabusCommand = ReactiveCommand.Create<Syllabus>(delSyllabus);

            CreateScheduleCommand = ReactiveCommand.Create(createSchedule);
            EditScheduleCommand = ReactiveCommand.Create(editSchedule);
            SettingScheduleCommand = ReactiveCommand.Create<Schedule>(settingSchedule);
            DelScheduleCommand = ReactiveCommand.Create<Schedule>(delSchedule);
            #endregion
        }

        #region Методы Учебного плана
        void createSyllabus() => _syllabusService.OpenWindowCreateSyllabus(_syllabusRepository);
        void editSyllabus(Syllabus syllabus) => _syllabusService.OpenWindowEditSyllabus(_syllabusRepository, syllabus);
        void settingSyllabus(Syllabus syllabus) => _syllabusService.OpenWindowSettingSyllabus(syllabus);
        void delSyllabus(Syllabus syllabus) => _syllabusRepository.DelSyllabus(syllabus);
        #endregion
        #region Методы Расписания
        void createSchedule() => _scheduleService.OpenWindowCreateSchedule(_scheduleRepository, Syllabus);
        void editSchedule() { }
        void settingSchedule(Schedule schedule) => _scheduleService.OpenWindowSettingSchedule(schedule);
        void delSchedule(Schedule schedule) => _scheduleRepository.DelSchedule(schedule);
        #endregion
    }
}