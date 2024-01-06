using System;

namespace ERPeducation.Models.AdmissionCampaign.Documents
{
    public class Passport : DocsBase
    {
        //Данные паспорта
        public string IssuedBy { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string DepartmentCode { get; set; }
        public string SeriesNumber { get; set; }

        //Личный данные
        public string SurName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }

        //Регистрация по месту жительства
        public string Location { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Frame { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
