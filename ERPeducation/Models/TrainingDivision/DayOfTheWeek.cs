using Newtonsoft.Json;

namespace ERPeducation.Models.TrainingDivision
{
    [JsonObject]
    public class DayOfTheWeek
    {
        public string Понедельник { get; set; } = string.Empty;
        public string Вторник { get; set; } = string.Empty;
        public string Среда{ get; set; } = string.Empty;
        public string Четверг{ get; set; } = string.Empty;
        public string Пятница { get; set; } = string.Empty;
        public string Суббота { get; set; } = string.Empty;
        public string Воскресенье { get; set; } = string.Empty;
    }
}