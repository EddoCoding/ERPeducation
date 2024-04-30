using Newtonsoft.Json;

namespace ERPeducation.Models.DeanRoom
{
    [JsonObject]
    public class Student
    {
        public string SurName { get; set; }
        public string Name { get; set; }
        public string MiddleSuName { get; set; }
        public string FullName { get; set; }
        public string NameGroup { get; set; }

        public Student() => FullName = $"{SurName} {Name} {MiddleSuName}";

        // -- Добавить еще свойства --

        // -- Класс успеваемости(Оценки и Посещаемость) --
        // -- Финансовая часть
        // -- Еще что-нибудь --
    }
}