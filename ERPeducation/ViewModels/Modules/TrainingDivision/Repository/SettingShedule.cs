using ERPeducation.Models.TrainingDivision;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Repository
{
    public class SettingShedule : ISettingSchedule
    {
        List<DayOfTheWeek> GetPoints()
        {
            List<DayOfTheWeek> list = new List<DayOfTheWeek>();
            for (int i = 0; i < 8; i++) list.Add(new DayOfTheWeek());
            return list;
        }

        public ObservableCollection<DataGrid> WeekDataGrids { get; set; } = new();
        public void GenerationWeekDataGrids(int countWeek)
        {
            WeekDataGrids.Clear();
            for(int i = 0; i < countWeek; i++) WeekDataGrids.Add(new DataGrid()
            {
                ItemsSource = new ObservableCollection<DayOfTheWeek>(GetPoints())
            });
        }
    }
}