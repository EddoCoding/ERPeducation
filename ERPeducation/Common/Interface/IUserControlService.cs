using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel;
using System.Windows.Controls;
using System;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.PersonalInformation;

namespace ERPeducation.Common.Interface
{
    public interface IUserControlService
    {
        public UserControl GetUserControl(string? titleButton, object viewModel);
        public UserControl GetUserControlForAdmissionCampaign(string TitleTab);
        public UserControl GetUserControlForModuleEnrollee(string moduleEnrolle);
        public UserControl GetUserControlForDocuments(string? documents, EnrollePersonalInformationViewModel viewModel, Action closeWindow);
        public UserControl GetUserControlForTypeEducationDocument(string typeEducation, EnrolleeEducationViewModel viewModel, Action closeWindow);


        public UserControl GetUserControlForAdministrationView();
        public UserControl GetUserControlForAdministrationStruct();
    }
}
