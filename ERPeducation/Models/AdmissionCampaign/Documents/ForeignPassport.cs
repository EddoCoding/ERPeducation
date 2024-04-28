using Newtonsoft.Json;
using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents
{
    [JsonObject]
    public class ForeignPassport : DocumentBase
    {
        public string IssuedBy { get; set; } = string.Empty;
        public DateTime DateOfIssue { get; set; }
        public string Series { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;

        public ForeignPassport()
        {
            TypeDocument = "Иностранный паспорт";
        }
    }
}
