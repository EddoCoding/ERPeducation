using ERPeducation.Models.AdmissionCampaign.Documents;
using ERPeducation.Models.AdmissionCampaign.EducationDocuments;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.PersonalInformation;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Interface.DialogPersonal
{
    public interface IDialogService
    {
        void OpenWindow(object viewModel);
        void OpenMainWindow();
        public void OpenWindowEditPersonalDocument(DocsBase userControl, EnrollePersonalInformationViewModel viewModel);
        public void OpenWindowEditEducationDocument(TypeEducationBaseModel userControl, EnrolleeEducationViewModel viewModel, int selectedItemInt);
        public void OpenWindowStructEducation(ObservableCollection<string> education1, string education2);
    }
}