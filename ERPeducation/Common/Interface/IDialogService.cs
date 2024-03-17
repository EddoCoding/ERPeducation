using ERPeducation.Common.Windows.AddUser;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Interface.DialogPersonal
{
    public interface IDialogService
    {
        string OpenPathDialog();
        void OpenAuthorizationWindow();
        void OpenMainWindow(UserViewModel user, Action closeWindow);
        void OpenWindowAddUser(ObservableCollection<UserViewModel> users);
        void OpenWindowChangeUser(ObservableCollection<UserViewModel> users, UserViewModel userModel);
    }
}