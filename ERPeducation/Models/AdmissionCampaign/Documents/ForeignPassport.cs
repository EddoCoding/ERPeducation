using System;

namespace ERPeducation.Models.AdmissionCampaign.Documents
{
    public class ForeignPassport : DocsBase
    {
        //Данные паспорта
        public string Abbreviation { get; set; }
        public string Number { get; set; }
        public string IssuedBy { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime Validity { get; set; }

        //Личный данные
        public string SurName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Citizenship { get; set; }
    }
}
