using ERPeducation.Models.TrainingDivision;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.Models
{
    [JsonObject]
    public class Semestr : ReactiveObject
    {
        public int NumberSemestr { get; set; }


        // -- Блок занятий --
        public ObservableCollection<Discipline> Disciplines { get; set; }
        public DateTime ClassPeriodFrom { get; set; }
        public DateTime ClassPeriodUpTo { get; set; }
        ObservableCollection<Coursework> сourseworks;
        public ObservableCollection<Coursework> Courseworks
        {
            get => сourseworks;
            set => this.RaiseAndSetIfChanged(ref сourseworks, value);
        }

        public int CountSubject => Disciplines.Count;

        int sumLectureHours;
        public int SumLectureHours
        {
            get
            {
                sumLectureHours = 0;
                foreach (var discipline in Disciplines)
                    sumLectureHours += discipline.LectureHours;
                return sumLectureHours;
            }
            set => this.RaiseAndSetIfChanged(ref sumLectureHours, value);
        }

        int sumPracticeHours;
        public int SumPracticeHours
        {
            get
            {
                sumPracticeHours = 0;
                foreach (var discipline in Disciplines)
                    sumPracticeHours += discipline.PracticeHours;
                return sumPracticeHours;
            }
            set => this.RaiseAndSetIfChanged(ref sumPracticeHours, value);
        }

        int sumHours;
        public int SumHours
        {
            get
            {
                sumHours = 0;
                foreach (var hour in Disciplines)
                    sumHours += hour.SumHours;
                return sumHours;
            }
            set => this.RaiseAndSetIfChanged(ref sumHours, value);
        }

        public int CountCoursework => сourseworks.Count;


        // -- Блок сессии --
        public DateTime PeriodSessionFrom { get; set; }
        public DateTime PeriodSessionUpTo { get; set; }


        // -- Блок практики --
        public string TypeOfPractice { get; set; } = string.Empty;
        [JsonIgnore] public string[] TypesOfPractice { get; set; } = { "Нет практики", "Учебная практика", "Ознакомительная практика", "Производственная практика", "Преддипломная практика" };
        public DateTime PeriodPracticeFrom { get; set; }
        public DateTime PeriodPracticeUpTo { get; set; }


        // -- Блок каникул --
        public DateTime PeriodHolidaysFrom { get; set; }
        public DateTime PeriodHolidaysUpTo { get; set; }


        // -- Блок диплома --
        public DateTime PeriodProtectionFrom { get; set; }
        public DateTime PeriodProtectionUpTo { get; set; }

        [JsonIgnore] public ReactiveCommand<Unit, Unit> Command { get; set; }

        public Semestr()
        {
            Disciplines = new();
            Courseworks = new();

            Command = ReactiveCommand.Create(UpdateDataSemestr);
        }

        void UpdateDataSemestr()
        {
            SumLectureHours = 0;
            SumPracticeHours = 0;
            SumHours = 0;

            foreach(var discipline in Disciplines)
            {
                SumLectureHours = discipline.LectureHours;
                SumPracticeHours = discipline.PracticeHours;
                SumHours = discipline.SumHours;
            }   
        }       
    }
}