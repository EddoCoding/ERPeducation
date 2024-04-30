using Newtonsoft.Json;
using System.Collections.Generic;

namespace ERPeducation.Models.DeanRoom
{
    [JsonObject]
    public class Faculty
    {
        public string NameFaculty { get; set; }
        public List<LvlOfTraining> Levels { get; set; }

        public Faculty() => Levels = new List<LvlOfTraining>();
    }
}