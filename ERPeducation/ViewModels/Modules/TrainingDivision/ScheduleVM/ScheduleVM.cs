using ERPeducation.Models;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.ScheduleVM
{
    public class ScheduleVM
    {
        public string TitleSchedule { get; set; } = string.Empty;
        public Syllabus Syllabus { get; set; }
    }
}