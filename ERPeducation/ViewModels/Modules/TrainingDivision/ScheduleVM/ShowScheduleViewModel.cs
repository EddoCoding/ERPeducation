using ERPeducation.Common.BD;
using ERPeducation.Models.TrainingDivision;
using ERPeducation.ViewModels.Modules.TrainingDivision.Repository;
using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Windows.Controls;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.ScheduleVM
{
    public class ShowScheduleViewModel : ReactiveObject
    {
        public Schedule Schedule { get; set; }
        public ObservableCollection<DataGrid> WeekDataGrids { get; set; } = new();

        Action _closeWindow;

        public ShowScheduleViewModel(string titleSchedule, Action closeWindow)
        {
            var file = File.ReadAllText(Path.Combine(FileServer.Schedule, $"{titleSchedule}.json"));
            Schedule = JsonConvert.DeserializeObject<Schedule>(file);

            _closeWindow = closeWindow;

            if (File.Exists(Path.Combine(FileServer.DataGrids, $"{titleSchedule}.json")))
            {
                string json = File.ReadAllText(Path.Combine(FileServer.DataGrids, $"{titleSchedule}.json"));
                var anonymousDataGrids = JsonConvert.DeserializeObject<List<dynamic>>(json);
                var itemsSources = anonymousDataGrids.Select(x => x.ItemsSource);

                for (int i = 0; i < itemsSources.Count(); i++)
                    WeekDataGrids.Add(new DataGrid() { ItemsSource = itemsSources.ToArray()[i].ToObject<List<DayOfTheWeek>>() });
            }

            CloseWindowCommand = ReactiveCommand.Create(Exit);
        }

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }

        void Exit() => _closeWindow();
    }
}