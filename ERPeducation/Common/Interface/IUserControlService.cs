using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel;
using System.Windows.Controls;
using System;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.PersonalInformation;

namespace ERPeducation.Common.Interface
{
    public interface IUserControlService
    {
        UserControl GetUserControl(string? titleButton, object viewModel);
        UserControl GetUserControlForAdmissionCampaign(string TitleTab);
        UserControl GetUserControlForModuleEnrollee(string moduleEnrolle);
        UserControl GetUserControlForDocuments(string? documents, EnrollePersonalInformationViewModel viewModel, Action closeWindow);
        UserControl GetUserControlForTypeEducationDocument(string typeEducation, EnrolleeEducationViewModel viewModel, Action closeWindow);


        UserControl GetUserControlForAdministrationView();
        UserControl GetUserControlForAdministrationStruct();
    }
}
