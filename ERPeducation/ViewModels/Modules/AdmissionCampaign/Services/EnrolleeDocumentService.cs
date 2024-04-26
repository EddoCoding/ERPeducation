using ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents;
using ERPeducation.Views.AdmissionCampaign.WindowDocuments;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Services
{
    public class EnrolleeDocumentService : IEnrolleeDocumentService
    {
        public void OpenWindowCreateDocument(IEnrolleeRepository repository, string typeDocument)
        {
            switch (typeDocument)
            {
                case "Passport":
                    PassportWindow passportWindow = new PassportWindow();
                    passportWindow.DataContext = new PassportViewModel(repository, passportWindow.Close);
                    passportWindow.ShowDialog();
                    break;
                case "Snils":
                    SnilsWindow snilsWindow = new SnilsWindow();
                    snilsWindow.DataContext = new SnilsViewModel(repository, snilsWindow.Close);
                    snilsWindow.ShowDialog();
                    break;
                case "INN":
                    INNWindow innWindow = new INNWindow();
                    innWindow.DataContext = new INNViewModel(repository, innWindow.Close);
                    innWindow.ShowDialog();
                    break;
                case "ForeignPassport":
                    ForeignPassportWindow foreignPassportWindow = new ForeignPassportWindow();
                    foreignPassportWindow.DataContext = new ForeignPassportViewModel(repository, foreignPassportWindow.Close);
                    foreignPassportWindow.ShowDialog();
                    break;
            }
        }
    }
}
