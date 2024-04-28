using Newtonsoft.Json;
using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents
{
    [JsonObject]
    public class INN : DocumentBase
    {
        public string NumberINN { get; set; } = string.Empty;
        public DateTime DateAssigned { get; set; }
        public string Series { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;

        public INN()
        {
            TypeDocument = "ИНН";
        }
    }
}