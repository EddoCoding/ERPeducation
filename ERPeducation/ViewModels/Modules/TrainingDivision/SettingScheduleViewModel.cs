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
    public class SettingScheduleViewModel
    {
        public Schedule Schedule { get; set; }
        [Reactive] public Semestr SelectedSemester { get; set; }

        public ObservableCollection<DataGrid> WeekDataGrids { get; set; } = new();

        #region Команды
        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Unit,Unit> SettingScheduleCommand { get; set; }
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

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            SettingScheduleCommand = ReactiveCommand.Create(SettingSchedule);
            GenerationWeeksCommand = ReactiveCommand.Create(GenerationWeeks);
        }

        #region Методы
        void Exit() => _closeWindow();
        void SettingSchedule()
        {

            _closeWindow();
        }
        void GenerationWeeks() => _settingShedule.GenerationWeekDataGrids();
        #endregion
    }
}