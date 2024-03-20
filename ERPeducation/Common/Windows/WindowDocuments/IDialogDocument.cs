using ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Windows.WindowDocuments
{
    public interface IDialogDocument
    {
        void GetPassport(ObservableCollection<PersonalDocumentBase> documents);
        void GetPassport(PassportViewModel document);
        void GetSnils(ObservableCollection<PersonalDocumentBase> documents);
        void GetSnils(SnilsViewModel document);
        void GetInn(ObservableCollection<PersonalDocumentBase> documents);
        void GetInn(InnViewModel document);
        void GetForeignPassport(ObservableCollection<PersonalDocumentBase> documents);
        void GetForeignPassport(ForeignPassportViewModel document);
    }
}