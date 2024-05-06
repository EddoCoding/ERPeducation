using Newtonsoft.Json;
using System;

namespace ERPeducation.Models.AdmissionCampaign.Directions.TestEGG
{
    [JsonObject]
    public class Test : TestEGEBase
    {
        public DateTime When { get; set; }
        public DateTime AtWhatTime { get; set; }
        public string Room { get; set; } = string.Empty;
        public string StatusTest { get; set; } = "Испытание не проведено";

        [JsonIgnore] public string[] Status { get; set; } = { "Испытание не проведено", "Испытание не пройдено", "Испытание пройдено" };
    }
}