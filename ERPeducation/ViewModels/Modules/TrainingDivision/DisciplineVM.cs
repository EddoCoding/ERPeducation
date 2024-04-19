using Newtonsoft.Json;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class DisciplineVM
    {
        public string TitleSubject { get; set; } = string.Empty;
        public int LectureHours { get; set; }
        public int PracticeHours { get; set; }
        public string TypeOfControl { get; set; } = string.Empty;
    }
}