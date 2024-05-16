using ERPeducation.Models;
using ERPeducation.ViewModels.Modules.TrainingDivision.Repository;
using ERPeducation.ViewModels.Modules.TrainingDivision.ScheduleVM;
using ERPeducation.Views.TrainingDivision.WindowSchedule;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Service
{
    public class ScheduleService : IScheduleService
    {
        public void OpenWindowCreateSchedule(IScheduleRepository scheduleRepository, ObservableCollection<Syllabus> syllabus) 
        {
            CreateScheduleWindow window = new();
            window.DataContext = new CreateScheduleViewModel(scheduleRepository, syllabus, window.Close);
            window.ShowDialog();
        }
        public void OpenWindowEditSchedule() { }
        public void OpenWindowSettingSchedule() { }
    }
}