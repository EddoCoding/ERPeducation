using ERPeducation.Models.TrainingDivision;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        public ObservableCollection<Schedule> Schedules { get; set; } = new();
        public void AddSchedule(Schedule schedule) => Schedules.Add(schedule);
    }
}