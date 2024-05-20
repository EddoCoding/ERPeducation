using Newtonsoft.Json;

namespace ERPeducation.Models.TrainingDivision
{
    [JsonObject]
    public class Schedule
    {
        public string TitleSchedule { get; set; } = string.Empty;
        public string TitleSyllabus { get; set; } = string.Empty;
        public Semestr Semestr { get; set; } = new();
    }
}