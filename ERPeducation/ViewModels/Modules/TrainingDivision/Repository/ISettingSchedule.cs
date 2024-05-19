using ERPeducation.Models.TrainingDivision;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Repository
{
    public interface ISettingSchedule
    {
        ObservableCollection<DataGrid> WeekDataGrids { get; set; }
        void GenerationWeekDataGrids(int countWeek);
        void SaveSchedule(Schedule Schedule);
        void GetInfoWeekDataGrids(Schedule schedule);
    }
}