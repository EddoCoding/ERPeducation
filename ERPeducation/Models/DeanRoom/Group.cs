using Newtonsoft.Json;
using System.Collections.Generic;

namespace ERPeducation.Models.DeanRoom
{
    [JsonObject]
    public class Group
    {
        public string NameGroup { get; set; }
        public string Direction { get; set; }
        public List<Student> Students { get; set; }

        public Group() => Students = new List<Student>();
    }
}
