using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents
{
    public class INN : DocumentBase
    {
        public string NumberINN { get; set; } = "Номер ИНН";
        public DateTime DateAssigned { get; set; } = DateTime.Now;
        public string Series { get; set; } = "Серия ИНН";
        public string Number { get; set; } = "Номер ИНН";

        public INN()
        {
            TypeDocument = "ИНН";
        }
    }
}