using Newtonsoft.Json;
using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents
{
    [JsonObject]
    public class Snils : DocumentBase
    {
        public string Number { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }

        public Snils()
        {
            TypeDocument = "Снилс";
        }
    }
}
