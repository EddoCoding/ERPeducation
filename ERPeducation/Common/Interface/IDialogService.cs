using ERPeducation.Models;
using ERPeducation.Models.AdmissionCampaign.Documents;
using ERPeducation.Models.AdmissionCampaign.EducationDocuments;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.PersonalInformation;

namespace ERPeducation.Common.Interface.DialogPersonal
{
    public interface IDialogService
    {
        string OpenPathDialog();
        string CreateBase();
        void OpenAuthorizationWindow();
        void OpenWindow(object viewModel);
        void OpenMainWindow(UserModel user);
        public void OpenWindowEditPersonalDocument(DocsBase userControl, EnrollePersonalInformationViewModel viewModel);
        public void OpenWindowEditEducationDocument(TypeEducationBaseModel userControl, EnrolleeEducationViewModel viewModel, int selectedItemInt);
    }
}