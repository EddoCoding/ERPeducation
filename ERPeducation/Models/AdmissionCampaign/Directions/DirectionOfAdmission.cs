using Newtonsoft.Json;
using System.Collections.Generic;

namespace ERPeducation.Models.AdmissionCampaign.Direction
{
    [JsonObject]
    public class DirectionOfAdmission
    {
        public string NameFaculty { get; set; }
        public string NameLevel { get; set; }
        public string NameForm { get; set; }
        public string NameType { get; set; }
        public string NameDirection { get; set; }

        public IEnumerable<Test> Tests { get; set; }
    }
}