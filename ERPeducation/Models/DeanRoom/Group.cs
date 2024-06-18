using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ERPeducation.Models.DeanRoom
{
    [JsonObject]
    public class Group
    {
        public string TitleFaculty { get; set; }
        public string TitleLevel { get; set; }
        public string TitleForm { get; set; }
        public string TitleTypeGroup { get; set; }
        public string NameGroup { get; set; }
        public string Direction { get; set; }
        public ObservableCollection<Student> Students { get; set; }
        public string Syllabus { get; set; }
        public string Schedule { get; set; }
        public string AcademicPerformance { get; set; }

        public Group() => Students = new ObservableCollection<Student>();
    }
}