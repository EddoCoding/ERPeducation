using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Repository
{
    public class SettingShedule : ISettingSchedule
    {
        public ObservableCollection<DataGrid> WeekDataGrids { get; set; } = new();
        public void GenerationWeekDataGrids() => WeekDataGrids.Add(new DataGrid());
    }
}