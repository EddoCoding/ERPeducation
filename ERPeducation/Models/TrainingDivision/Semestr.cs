using ERPeducation.Models.TrainingDivision;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ERPeducation.Models
{
    [JsonObject]
    public class Semestr
    {
        public int NumberSemestr { get; set; }


        // -- Блок занятий --
        public List<Discipline> Disciplines { get; set; }
        public int SumStudyHours { get; set; }
        public DateTime ClassPeriodFrom { get; set; }
        public DateTime ClassPeriodUpTo { get; set; }
        public List<Coursework> Courseworks { get; set; }


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

        public Semestr()
        {
            Disciplines = new();
            Courseworks = new();
        }
    }
}