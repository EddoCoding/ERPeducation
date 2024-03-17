using ERPeducation.Common.Interface;
using ERPeducation.ViewModels;
using ERPeducation.ViewModels.Modules.Administration;
using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.PersonalInformation;
using ERPeducation.Views;
using ERPeducation.Views.Administration;
using ERPeducation.Views.AdmissionCampaign;
using ERPeducation.Views.AdmissionCampaign.NewView;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.Common.Services
{
    public class UserControlService : IUserControlService
    {
        //ВКЛАДКА МОДУЛЯ ПРИЕМНАЯ КАМПАНИЯ
        public UserControl GetModuleAdmissionCampaign(BaseDataForModules<TabItemMainWindowViewModel> data) => 
            new AdmissionCampaign() { DataContext = new AdmissionCampaignViewModel(this, data) };

        //ВКЛАДКА МОДУЛЯ АДМИНИСТРИРОВАНИЕ
        public UserControl GetModuleAdministration() => 
            new ModuleAdministration() { DataContext = new AdministrationViewModel(this) };

        //ВКЛАДКА ДОБАВЛЕНИЯ АБИТУРИЕНТА
        public UserControl GetUserControlEnrollee(ObservableCollection<AddEnrolleeViewModel> enrollees) =>
            new AddEnrolleView() { DataContext = new AddEnrolleeViewModel(enrollees) };






        public UserControl GetUserControlForAdministrationView() =>
            new AdministrationUsersView() { DataContext = new AdministrationUserViewModel(new DialogService(), new JSONService()) };
        public UserControl GetUserControlForAdministrationStruct() => 
            new AdministrationStructView() { DataContext = new AdministrationStructViewModel(new JSONService()) };

        public UserControl GetUserControlForModuleEnrollee(string moduleEnrolle)
        {
            throw new NotImplementedException();
        }

        public UserControl GetUserControlForDocuments(string? documents, EnrollePersonalInformationViewModel viewModel, Action closeWindow)
        {
            throw new NotImplementedException();
        }

        public UserControl GetUserControlForTypeEducationDocument(string typeEducation, EnrolleeEducationViewModel viewModel, Action closeWindow)
        {
            throw new NotImplementedException();
        }
    }
}