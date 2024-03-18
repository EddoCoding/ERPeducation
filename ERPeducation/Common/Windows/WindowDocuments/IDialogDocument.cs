using ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Windows.WindowDocuments
{
    public interface IDialogDocument
    {
        void GetPassport(ObservableCollection<PersonalDocumentBase> documents);
        void GetSnils(ObservableCollection<PersonalDocumentBase> documents);
        void GetInn(ObservableCollection<PersonalDocumentBase> documents);
        void GetForeignPassport(ObservableCollection<PersonalDocumentBase> documents);
    }
}