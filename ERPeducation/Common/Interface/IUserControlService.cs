using ERPeducation.Models;
using ERPeducation.ViewModels;
using System.Windows.Controls;

namespace ERPeducation.Common.Interface
{
    public interface IUserControlService
    {
        UserControl GetModuleDeanRoom();
        UserControl GetModuleTrainingDivision();
        UserControl GetModuleAdmissionCampaign(MainTabControl<MainTabItem> data);
        UserControl GetModuleAdministration();
        UserControl GetUserControlForAdministrationView();
        UserControl GetUserControlForAdministrationStruct();
    }
}
