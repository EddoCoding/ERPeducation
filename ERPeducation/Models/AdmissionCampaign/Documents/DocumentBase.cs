using Newtonsoft.Json;
using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents
{
    [JsonObject]
    public class DocumentBase
    {
        public string TypeDocument { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; } = string.Empty;
        public string AdditionalInformation { get; set; } = string.Empty;
    }
}