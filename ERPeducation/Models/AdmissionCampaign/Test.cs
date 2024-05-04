using Newtonsoft.Json;
using System;

namespace ERPeducation.Models.AdmissionCampaign
{
    [JsonObject]
    public class Test
    {
        public string Subject { get; set; } = string.Empty;
        public DateTime When { get; set; }
        public DateTime AtWhatTime { get; set; }
        public string Room { get; set; } = string.Empty;
        public string StatusTest { get; set; } = string.Empty;
        public double Points { get; set; }
    }
}