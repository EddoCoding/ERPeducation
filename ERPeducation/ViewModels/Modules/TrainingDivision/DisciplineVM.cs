using System.Collections.Generic;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class DisciplineVM
    {
        public string Subject { get; set; } = string.Empty;
        public int LectureHours { get; set; }
        public int PracticeHours { get; set; }
        public string TypeOfControl { get; set; } = string.Empty;
        public int Semester { get; set; }
        public List<string>? Topics { get; set; }
    }
}