using ERPeducation.Common.Interface;
using ERPeducation.Models;
using ERPeducation.ViewModels;
using ERPeducation.ViewModels.Modules.Administration;
using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using ERPeducation.Views;
using ERPeducation.Views.Administration;
using ERPeducation.Views.AdmissionCampaign;
using ERPeducation.Views.AdmissionCampaign.NewView;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.Common.Services
{
    public class UserControlService : IUserControlService
    {
        //ВКЛАДКА МОДУЛЯ ПРИЕМНАЯ КАМПАНИЯ
        public UserControl GetModuleAdmissionCampaign(MainTabControl<MainTabItem> data) => 
            new AdmissionCampaign() { DataContext = new AdmissionCampaignViewModel(this, new JSONService(), data) };

        //ВКЛАДКА МОДУЛЯ АДМИНИСТРИРОВАНИЕ
        public UserControl GetModuleAdministration() => 
            new ModuleAdministration() { DataContext = new AdministrationViewModel(this) };


        //ВКЛАДКА ДОБАВЛЕНИЯ АБИТУРИЕНТА
        public UserControl GetUserControlEnrollee(ObservableCollection<AddChangeEnrolleeViewModel> enrollees, MainTabControl<MainTabItem> data) =>
            new AddEnrolleView() { DataContext = new AddChangeEnrolleeViewModel(enrollees, data) };


        //ПОЛУЧЕНИЕ КРАТКОЙ ИНФОРМАЦИИ ОБ АБИТУРИЕНТЕ В UserControl
        public void GetInfoEnrollee(UserControl userControlEnrollee, AddChangeEnrolleeViewModel selectedEnrollee) =>
            userControlEnrollee.Content = new InfoEnrolleeUserControl() { DataContext = selectedEnrollee };

        public UserControl GetUserControlForAdministrationView() =>
            new AdministrationUsersView() { DataContext = new AdministrationUserViewModel(new DialogService(), new JSONService()) };
        public UserControl GetUserControlForAdministrationStruct() => 
            new AdministrationStructView() { DataContext = new AdministrationStructViewModel(new JSONService()) };
    }
}