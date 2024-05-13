using Newtonsoft.Json;
using ReactiveUI;

namespace ERPeducation.Models.TrainingDivision
{
    [JsonObject]
    public class Coursework : ReactiveObject
    {
        public string NameSubject { get; set; } = "Введите предмет курсовой";
    }
}