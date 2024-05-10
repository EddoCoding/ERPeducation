using Newtonsoft.Json;

namespace ERPeducation.Models.DeanRoom
{
    [JsonObject]
    public class Student
    {
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;

        public string TitleFaculty { get; set; } = string.Empty;
        public string TitleLevel { get; set; } = string.Empty;
        public string TitleForm { get; set; } = string.Empty;
        public string TitleTypeGroup { get; set; } = string.Empty;
        public string TitleGroup { get; set; } = string.Empty;
        public string TitleDirection { get; set; } = string.Empty;

        // -- Класс успеваемости(Оценки и Посещаемость) --
        // -- Финансовая часть
        // -- Еще что-нибудь --
    }
}