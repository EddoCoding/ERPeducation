using Newtonsoft.Json;

namespace ERPeducation.Models.TrainingDivision
{
    [JsonObject]
    public class Discipline
    {
        public string NameSubject { get; set; } = string.Empty;
        public string TypeOfControl { get; set; } = string.Empty;
        public int LectureHours { get; set; }
        public int PracticeHours { get; set; }
    }
}