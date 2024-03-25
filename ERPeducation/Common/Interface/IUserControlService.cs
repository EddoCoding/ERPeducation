using ERPeducation.Models;
using ERPeducation.ViewModels;
using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.Common.Interface
{
    public interface IUserControlService
    {
        UserControl GetModuleAdmissionCampaign(MainTabControl<MainTabItem> data);
        UserControl GetModuleAdministration();


        UserControl GetUserControlEnrollee(ObservableCollection<AddChangeEnrolleeViewModel> enrollees);



        UserControl GetUserControlForAdministrationView();
        UserControl GetUserControlForAdministrationStruct();
    }
}
