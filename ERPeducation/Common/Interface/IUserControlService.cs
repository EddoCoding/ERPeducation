using ERPeducation.ViewModels;
using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.PersonalInformation;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.Common.Interface
{
    public interface IUserControlService
    {
        UserControl GetModuleAdmissionCampaign(BaseDataForModules<TabItemMainWindowViewModel> data);
        UserControl GetModuleAdministration();

        UserControl GetUserControlEnrollee(ObservableCollection<AddEnrolleeViewModel> enrollees);




        UserControl GetUserControlForModuleEnrollee(string moduleEnrolle);
        UserControl GetUserControlForDocuments(string? documents, EnrollePersonalInformationViewModel viewModel, Action closeWindow);
        UserControl GetUserControlForTypeEducationDocument(string typeEducation, EnrolleeEducationViewModel viewModel, Action closeWindow);


        UserControl GetUserControlForAdministrationView();
        UserControl GetUserControlForAdministrationStruct();
    }
}
