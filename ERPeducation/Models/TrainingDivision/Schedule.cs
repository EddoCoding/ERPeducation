using Newtonsoft.Json;

namespace ERPeducation.Models.TrainingDivision
{
    [JsonObject]
    public class Schedule
    {
        public string TitleSchedule { get; set; } = string.Empty;
        public Syllabus Syllabus { get; set; }
    }
}