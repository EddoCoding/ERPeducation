using System;

namespace ERPeducation.Models.AdmissionCampaign.Documents
{
    public class INN : DocsBase
    {
        public DateTime DateOfAssignment { get; set; }
        public long NumberINN { get; set; }
        public string Organization {  get; set; }
        public string SeriesNumber {  get; set; }
    }
}
