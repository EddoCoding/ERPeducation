using ERPeducation.Models.AdmissionCampaign.Educations;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents.EditDocument;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Educations.AddEducation;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Educations.EditEducation;
using ERPeducation.Views.AdmissionCampaign.WindowDirections;
using ERPeducation.Views.AdmissionCampaign.WindowDocuments;
using ERPeducation.Views.AdmissionCampaign.WindowDocuments.EditDocument;
using ERPeducation.Views.AdmissionCampaign.WindowEducations.AddEducation;
using ERPeducation.Views.AdmissionCampaign.WindowEducations.EditEducation;

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
        public void OpenWindowEditDocument(DocumentBase document)
        {
            if(document is Passport)
            {
                EditPassportWindow passportWindow = new EditPassportWindow();
                passportWindow.DataContext = new EditPassportViewModel(document, passportWindow.Close);
                passportWindow.ShowDialog();
                return;
            }
            if (document is Snils)
            {
                EditSnilsWindow snilsWindow = new EditSnilsWindow();
                snilsWindow.DataContext = new EditSnilsViewModel(document, snilsWindow.Close);
                snilsWindow.ShowDialog();
                return;
            }
            if (document is INN)
            {
                EditINNWindow iNNWindow = new EditINNWindow();
                iNNWindow.DataContext = new EditINNViewModel(document, iNNWindow.Close);
                iNNWindow.ShowDialog();
                return;
            }
            if (document is ForeignPassport)
            {
                EditForeignPassportWindow foreignPassportWindow = new EditForeignPassportWindow();
                foreignPassportWindow.DataContext = new EditForeignPassportViewModel(document, foreignPassportWindow.Close);
                foreignPassportWindow.ShowDialog();
                return;
            }
        }

        public void OpenWindowCreateEducation(IEnrolleeRepository repository, string education)
        {
            switch (education)
            {
                case "Nine":
                    NineWindow nineWindow = new NineWindow();
                    nineWindow.DataContext = new NineViewModel(repository, nineWindow.Close);
                    nineWindow.ShowDialog();
                    break;
                case "Eleven":
                    ElevenWindow elevenWindow = new ElevenWindow();
                    elevenWindow.DataContext = new ElevenViewModel(repository, elevenWindow.Close);
                    elevenWindow.ShowDialog();
                    break;
                case "SPO":
                    SPOWindow sPOWindow = new SPOWindow();
                    sPOWindow.DataContext = new SPOViewModel(repository, sPOWindow.Close);
                    sPOWindow.ShowDialog();
                    break;
                case "Bak":
                    BakWindow bakWindow = new BakWindow();
                    bakWindow.DataContext = new BakViewModel(repository, bakWindow.Close);
                    bakWindow.ShowDialog();
                    break;
                case "Mag":
                    MagWindow magWindow = new MagWindow();
                    magWindow.DataContext = new MagViewModel(repository, magWindow.Close);
                    magWindow.ShowDialog();
                    break;
                case "Asp":
                    AspWindow aspWindow = new AspWindow();
                    aspWindow.DataContext = new AspViewModel(repository, aspWindow.Close);
                    aspWindow.ShowDialog();
                    break;
            }
        }
        public void OpenWindowEditEducation(EducationBase education)
        {
            if(education is EducationNine)
            {
                EditNineWindow nineWindow = new EditNineWindow();
                nineWindow.DataContext = new EditNineViewModel(education, nineWindow.Close);
                nineWindow.ShowDialog();
                return;
            }
            if (education is EducationEleven)
            {
                EditElevenWindow elevenWindow = new EditElevenWindow();
                elevenWindow.DataContext = new EditElevenViewModel(education, elevenWindow.Close);
                elevenWindow.ShowDialog();
                return;
            }
            if (education is EducationSPO)
            {
                EditSPOWindow sPOWindow = new EditSPOWindow();
                sPOWindow.DataContext = new EditSPOViewModel(education, sPOWindow.Close);
                sPOWindow.ShowDialog();
                return;
            }
            if (education is EducationBak)
            {
                EditBakWindow bakWindow = new EditBakWindow();
                bakWindow.DataContext = new EditBakViewModel(education, bakWindow.Close);
                bakWindow.ShowDialog();
                return;
            }
            if (education is EducationMag)
            {
                EditMagWindow magWindow = new EditMagWindow();
                magWindow.DataContext = new EditMagViewModel(education, magWindow.Close);
                magWindow.ShowDialog();
                return;
            }
            if (education is EducationAsp)
            {
                EditAspWindow AspWindow = new EditAspWindow();
                AspWindow.DataContext = new EditAspViewModel(education, AspWindow.Close);
                AspWindow.ShowDialog();
                return;
            }
        }

        public void OpenWindowCreateDirection(IEnrolleeRepository repository)
        {
            DirectionWindow directionWindow = new DirectionWindow();
            directionWindow.DataContext = new DirectionViewModel(repository, directionWindow.Close);
            directionWindow.ShowDialog();
        }
    }
}