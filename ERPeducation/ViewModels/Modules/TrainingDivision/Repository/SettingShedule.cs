using ERPeducation.Common.BD;
using ERPeducation.Models.TrainingDivision;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Repository
{
    public class SettingShedule : ISettingSchedule
    {
        List<DayOfTheWeek> GetPoints()
        {
            List<DayOfTheWeek> list = new List<DayOfTheWeek>();
            for (int i = 0; i < 8; i++) list.Add(new DayOfTheWeek());
            return list;
        } //Сделать получение количества предметов из статической переменной

        public ObservableCollection<DataGrid> WeekDataGrids { get; set; } = new();
        public void GenerationWeekDataGrids(int countWeek)
        {
            WeekDataGrids.Clear();
            for(int i = 0; i < countWeek; i++) WeekDataGrids.Add(new DataGrid()
            {
                ItemsSource = new ObservableCollection<DayOfTheWeek>(GetPoints())
            });
        }
        public void SaveSchedule(Schedule schedule)
        {
            var anonymousDataGrids = WeekDataGrids.Select(x => new { ItemsSource = x.ItemsSource });
            string json = JsonConvert.SerializeObject(anonymousDataGrids, Formatting.Indented);
            File.WriteAllText(Path.Combine(FileServer.DataGrids, $"{schedule.TitleSchedule}.json"), json);
        }
        public void GetInfoWeekDataGrids(Schedule schedule)
        {
            if(File.Exists(Path.Combine(FileServer.DataGrids, $"{schedule.TitleSchedule}.json")))
            {
                string json = File.ReadAllText(Path.Combine(FileServer.DataGrids, $"{schedule.TitleSchedule}.json"));
                var anonymousDataGrids = JsonConvert.DeserializeObject<List<dynamic>>(json);
                var itemsSources = anonymousDataGrids.Select(x => x.ItemsSource);
                
                for (int i = 0; i < itemsSources.Count(); i++)
                    WeekDataGrids.Add(new DataGrid() { ItemsSource = itemsSources.ToArray()[i].ToObject<List<DayOfTheWeek>>() });
            }
        }
    }
}