using Microsoft.VisualBasic;
using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents
{
    public class DocumentBase
    {
        public string TypeDocument { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; } = string.Empty;
    }
}
