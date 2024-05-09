using Newtonsoft.Json;
using System.Collections.Generic;

namespace ERPeducation.Models.DeanRoom
{
    [JsonObject]
    public class FormsOfTraining
    {
        public string NameForm { get; set; }
        public string TitleFaculty { get; set; }
        public string TitleLevel { get; set; }
        public List<TypeGroup> TypeGroups { get; set; }

        public FormsOfTraining() => TypeGroups = new List<TypeGroup>();
    }
}