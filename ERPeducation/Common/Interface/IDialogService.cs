using ERPeducation.Models.AdmissionCampaign.Documents;
using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using System;
using System.Windows.Controls;

namespace ERPeducation.Common.Interface
{
    public interface IDialogService
    {
        void OpenWindow(object viewModel);
        void OpenMainWindow();
        public UserControl GetUserControl(string? titleButton, object viewModel);
        public UserControl GetUserControlForAdmissionCampaign(string TitleTab);
        public UserControl GetUserControlForModuleEnrollee(string moduleEnrolle);
        public UserControl GetUserControlForDocuments(string? documents, EnrollePersonalInformationViewModel viewModel, Action closeWindow);
        public void ShowUserControlDocumentsForEdit(DocsBase userControl, EnrollePersonalInformationViewModel viewModel);
    }
}