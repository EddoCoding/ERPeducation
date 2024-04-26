using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents
{
    public class Snils : DocumentBase
    {
        public string Number { get; set; } = "Номер снилса";
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public Snils()
        {
            TypeDocument = "Снилс";
        }
    }
}
