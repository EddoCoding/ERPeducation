using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents
{
    public class Passport : DocumentBase
    {
        public string IssuedBy { get; set; } = "ОУФМС";
        public DateTime DateOfIssue { get; set; } = DateTime.Now;
        public string DepartmentCode { get; set; } = "123-123";
        public string Series { get; set; } = "Серия паспорта";
        public string Number { get; set; } = "Номер паспорта";

        public Passport()
        {
            TypeDocument = "Паспорт";
        }
    }
}