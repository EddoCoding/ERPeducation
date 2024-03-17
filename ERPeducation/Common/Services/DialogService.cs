using ERPeducation.Command;
using ERPeducation.Common.BD;
using ERPeducation.Common.Interface.DialogPersonal;
using ERPeducation.Common.Services.ServiceForEducation;
using ERPeducation.Common.Services.ServicesForPersonalContact;
using ERPeducation.Common.Validator;
using ERPeducation.Common.Windows;
using ERPeducation.Common.Windows.AddUser;
using ERPeducation.Models.AdmissionCampaign.Documents;
using ERPeducation.Models.AdmissionCampaign.EducationDocuments;
using ERPeducation.ViewModels;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.FieldOfStudy;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.PersonalInformation;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace ERPeducation.Common.Services
{
    public class DialogService : ReactiveObject, IDialogService
    {
        public string OpenPathDialog()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            FileServer.PathIS = dialog.SelectedPath;
            return FileServer.PathIS;
        }

        //ОКНО АВТОРИЗАЦИИ
        public void OpenAuthorizationWindow()
        {
            Authorization authorization = new Authorization();
            authorization.DataContext = new AuthorizationViewModel(this, new Validator.UserValidation(), new JSONService(), 
                new DirectoryFile(), authorization.Close);
            authorization.Show();
        }

        //ОКНО ОСНОВНОЙ ПРОГРАММЫ
        public void OpenMainWindow(UserViewModel user, Action closeWindow)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = new MainWindowViewModel(new UserControlService(), mainWindow.Close, user)
            {
                RectorIsEnabled = user.RectorAccess,
                DeanRoomIsEnabled = user.DeanRoomAccess,
                TrainingDivisionIsEnabled = user.TrainingDivisionAccess,
                TeacherIsEnabled = user.TeacherAccess,
                AdmissionCampaignIsEnabled = user.AdmissionCampaignAccess,
                AdministrationIsEnabled = user.AdministrationAccess
            };
            mainWindow.Show();
            closeWindow();
        }

        //ОКНО ДОБАВЛЕНИЯ ПОЛЬЗОВАТЕЛЯ ERP_СИСТЕМЫ
        public void OpenWindowAddUser(ObservableCollection<UserViewModel> users)
        {
            WindowAddUser windowAddUser = new WindowAddUser();
            windowAddUser.DataContext = new AddUserViewModel(new ValidationString(), new GetModelService(), users, windowAddUser.Close);
            windowAddUser.ShowDialog();
        }

        //ОКНО ИЗМЕНЕНИЯ ПОЛЬЗОВАТЕЛЯ ERP_СИСТЕМЫ
        public void OpenWindowChangeUser(ObservableCollection<UserViewModel> users, UserViewModel userModel)
        {
            if (userModel.FullName == "Администратор") return;
            WindowAddUser windowAddUser = new WindowAddUser();
            windowAddUser.DataContext = new AddUserViewModel(new ValidationString(), new JSONService(), users, userModel, windowAddUser.Close)
            {
                TextAddlabbel = "Изменение данных пользователя",
                TextButonAddChange = "Изменить",

                FullName = userModel.FullName,
                Identifier = userModel.Identifier,

                RectorAccess = userModel.RectorAccess,
                DeanRoomAccess = userModel.DeanRoomAccess,
                TrainingDivisionAccess = userModel.TrainingDivisionAccess,
                TeacherAccess = userModel.TeacherAccess,
                AdmissionCampaignAccess = userModel.AdmissionCampaignAccess,
                AdministrationAccess = userModel.AdministrationAccess
            };
            windowAddUser.ShowDialog();
        }

        public void OpenWindow(object viewModel)
        {
            throw new NotImplementedException();
        }

        public void OpenWindowEditPersonalDocument(DocsBase userControl, EnrollePersonalInformationViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void OpenWindowEditEducationDocument(TypeEducationBaseModel userControl, EnrolleeEducationViewModel viewModel, int selectedItemInt)
        {
            throw new NotImplementedException();
        }
    }
}