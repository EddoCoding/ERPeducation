using ERPeducation.Common.Windows.AddUser;
using ERPeducation.Models.AdmissionCampaign.Documents;
using ERPeducation.Models.AdmissionCampaign.EducationDocuments;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.PersonalInformation;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Interface.DialogPersonal
{
    public interface IDialogService
    {
        string OpenPathDialog();
        void OpenAuthorizationWindow();
        void OpenWindow(object viewModel);
        void OpenMainWindow(UserViewModel user, Action closeWindow);
        void OpenWindowEditPersonalDocument(DocsBase userControl, EnrollePersonalInformationViewModel viewModel);
        void OpenWindowEditEducationDocument(TypeEducationBaseModel userControl, EnrolleeEducationViewModel viewModel, int selectedItemInt);
        void OpenWindowAddUser(ObservableCollection<UserViewModel> users);
        void OpenWindowChangeUser(ObservableCollection<UserViewModel> users, UserViewModel userModel);
    }
}