using ERPeducation.ViewModels;
using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.Common.Interface
{
    public interface IUserControlService
    {
        UserControl GetModuleAdmissionCampaign(BaseDataForModules<TabItemMainWindowViewModel> data);
        UserControl GetModuleAdministration();

        UserControl GetUserControlEnrollee(ObservableCollection<AddEnrolleeViewModel> enrollees);



        UserControl GetUserControlForAdministrationView();
        UserControl GetUserControlForAdministrationStruct();
    }
}
