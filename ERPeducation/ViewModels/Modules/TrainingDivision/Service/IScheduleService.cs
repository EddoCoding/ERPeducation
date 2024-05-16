using ERPeducation.Models;
using ERPeducation.ViewModels.Modules.TrainingDivision.Repository;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Service
{
    public interface IScheduleService
    {
        void OpenWindowCreateSchedule(IScheduleRepository scheduleRepository, ObservableCollection<Syllabus> syllabus);
        void OpenWindowEditSchedule();
        void OpenWindowSettingSchedule();
    }
}