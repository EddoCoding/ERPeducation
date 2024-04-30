using Newtonsoft.Json;
using System.Collections.Generic;

namespace ERPeducation.Models.DeanRoom
{
    [JsonObject]
    public class LvlOfTraining
    {
        public string NameLevel { get; set; }
        public List<FormsOfTraining> Forms { get; set; }
        public string NameFaculty { get; set; }

        public LvlOfTraining() => Forms = new List<FormsOfTraining>();
    }
}