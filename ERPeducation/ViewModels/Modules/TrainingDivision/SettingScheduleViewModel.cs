using ERPeducation.Models;
using ERPeducation.Models.TrainingDivision;
using ERPeducation.ViewModels.Modules.TrainingDivision.Repository;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive;
using System.Windows.Controls;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class SettingScheduleViewModel : ReactiveObject
    {
        public Schedule Schedule { get; set; }
        [Reactive] public Semestr SelectedSemester { get; set; }
        public ObservableCollection<DataGrid> WeekDataGrids { get; set; } = new();

        #region Команды
        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Schedule, Unit> SettingScheduleCommand { get; set; }
        public ReactiveCommand<Unit, Unit> GenerationWeeksCommand { get; set; }
        #endregion

        Action _closeWindow;

        ISettingSchedule _settingShedule = new SettingShedule();
        public SettingScheduleViewModel(Schedule schedule, Action closeWindow)
        {
            Schedule = schedule;
            _closeWindow = closeWindow;

            _settingShedule.WeekDataGrids.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) WeekDataGrids.Add(e.NewItems[0] as DataGrid);
            };
            _settingShedule.GetInfoWeekDataGrids(Schedule);

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            SettingScheduleCommand = ReactiveCommand.Create<Schedule>(SettingSchedule);
            GenerationWeeksCommand = ReactiveCommand.Create(GenerationWeeks);
        }

        #region Методы
        void Exit() => _closeWindow();
        void SettingSchedule(Schedule schedule)
        {
            _settingShedule.SaveSchedule(schedule);
            _closeWindow();
        }
        void GenerationWeeks()
        {
            WeekDataGrids.Clear();
            TimeSpan ts = SelectedSemester.ClassPeriodUpTo - SelectedSemester.ClassPeriodFrom;
            _settingShedule.GenerationWeekDataGrids((int)Math.Ceiling(ts.TotalDays / 7));
        }
        #endregion
    }
}