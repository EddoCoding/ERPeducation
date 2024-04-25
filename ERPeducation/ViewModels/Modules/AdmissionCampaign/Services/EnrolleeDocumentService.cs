namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Services
{
    public class EnrolleeDocumentService : IEnrolleeDocumentService
    {
        public void OpenWindowCreateDocument(IEnrolleeRepository repository, string typeDocument)
        {
            switch (typeDocument)
            {
                case "Passport":
                    
                    break;
                case "Snils":
                    break;
                case "INN":
                    break;
                case "ForeignPassport":
                    break;
            }
        }
    }
}
