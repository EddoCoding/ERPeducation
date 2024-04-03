using ERPeducation.Models;
using ERPeducation.ViewModels;
using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.Common.Windows.WindowDocuments
{
    public interface IDialogDocument
    {
        void GetPassport(ObservableCollection<PersonalDocumentBase> documents);
        void GetPassport(PersonalDocumentBase document);

        void GetSnils(ObservableCollection<PersonalDocumentBase> documents);
        void GetSnils(PersonalDocumentBase document);

        void GetInn(ObservableCollection<PersonalDocumentBase> documents);
        void GetInn(PersonalDocumentBase document);

        void GetForeignPassport(ObservableCollection<PersonalDocumentBase> documents);
        void GetForeignPassport(PersonalDocumentBase document);

        void GetUserControlDocument(UserControl userControl, PersonalDocumentBase document);

        void ChangeEnrollee(AddChangeEnrolleeViewModel enrollee, MainTabControl<MainTabItem> data);
    }
}