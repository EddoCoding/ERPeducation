using Newtonsoft.Json;
using System.Collections.Generic;

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
        public List<Student> Students { get; set; }
        public Syllabus Syllabus { get; set; }

        public Group() => Students = new List<Student>();
    }
}