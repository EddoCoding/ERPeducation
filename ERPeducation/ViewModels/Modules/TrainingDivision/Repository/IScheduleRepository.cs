using ERPeducation.Models.TrainingDivision;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Repository
{
    public interface IScheduleRepository
    {
        ObservableCollection<Schedule> Schedules { get; set; }
        void AddSchedule(Schedule schedule);
    }
}