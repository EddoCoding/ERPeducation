using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents
{
    public class ForeignPassport : DocumentBase
    {
        public string IssuedBy { get; set; } = "в чуркистане";
        public DateTime DateOfIssue { get; set; } = DateTime.Now;
        public string Series { get; set; } = "серия чурки";
        public string Number { get; set; } = "номер чурки";

        public ForeignPassport()
        {
            TypeDocument = "Иностранный паспорт";
        }
    }
}
