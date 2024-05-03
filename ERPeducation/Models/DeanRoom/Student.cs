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

        // -- Добавить еще свойства --

        // -- Класс успеваемости(Оценки и Посещаемость) --
        // -- Финансовая часть
        // -- Еще что-нибудь --
    }
}