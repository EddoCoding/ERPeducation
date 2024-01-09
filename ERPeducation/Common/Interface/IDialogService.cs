using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using System.Windows.Controls;

namespace ERPeducation.Common.Interface
{
    public interface IDialogService
    {
        void OpenWindow(EnrollePersonalInformationViewModel documents);
        void OpenMainWindow();
        public UserControl GetUserControl(string? titleButton, object viewModel);
        public UserControl GetUserControlForAdmissionCampaign(string TitleTab);
        public UserControl GetUserControlForModuleEnrollee(string moduleEnrolle);
        public UserControl GetUserControlForDocuments(string documents);
    }
}