using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ERPeducation.Models.TrainingDivision
{
    [JsonObject]
    public class Discipline : ReactiveObject
    {
        [Reactive] public string NameSubject { get; set; } = "Введите название предмета";
        int lectureHours;
        public int LectureHours
        {
            get => lectureHours;
            set
            {
                this.RaiseAndSetIfChanged(ref lectureHours, value);
                SumHours = lectureHours + practiceHours;
            }
        }
        int practiceHours;
        public int PracticeHours
        {
            get => practiceHours;
            set
            {
                this.RaiseAndSetIfChanged(ref practiceHours, value);
                SumHours = lectureHours + practiceHours;
            }
        }
        [Reactive] public string TypeOfControl { get; set; } = string.Empty;
        [Reactive] public int SumHours {  get; set; }
    }
}