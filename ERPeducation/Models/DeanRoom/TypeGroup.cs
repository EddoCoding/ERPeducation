using Newtonsoft.Json;
using System.Collections.Generic;

namespace ERPeducation.Models.DeanRoom
{
    [JsonObject]
    public class TypeGroup
    {
        public string TitleFaculty { get; set; }
        public string TitleLevel { get; set; }
        public string TitleForm { get; set; }
        public string NameType { get; set; }
        public List<Group> Groups { get; set; }

        public TypeGroup() => Groups = new List<Group>();
    }
}