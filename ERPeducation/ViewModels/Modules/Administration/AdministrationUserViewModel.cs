using ERPeducation.Common.BD;
using ERPeducation.Common.Command;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Interface.DialogPersonal;
using ERPeducation.Common.Windows.AddUser;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.Administration
{
    public class AdministrationUserViewModel : ReactiveObject
    {
        public string TextSearch { get; set; }

        public ObservableCollection<UserViewModel> Users { get; set; }

        public ReactiveCommand<Unit, Unit> AddUser { get; set; }
        public ReactiveCommand<Unit, Unit> SearchCommand { get; set; }


        IDialogService _dialogService;
        public AdministrationUserViewModel(IDialogService dialogService, IJSONService jsonService)
        {
            _dialogService = dialogService;

            Users = new ObservableCollection<UserViewModel>();

            Users.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (UserViewModel item in e.OldItems)
                {
                    item.OnDelete -= deleteUserModel;
                    item.OnChange -= changeUserModel;
                }
                if (e.NewItems != null) foreach (UserViewModel item in e.NewItems)
                {
                    item.OnDelete += deleteUserModel;
                    item.OnChange += changeUserModel;
                }
            };

            jsonService.GetUserFileJson(Users);

            AddUser = ReactiveCommand.Create(() =>
            {
                dialogService.OpenWindowAddUser(Users);
            });

            SearchCommand = ReactiveCommand.Create(NotReady.Message);
        }

        void deleteUserModel(UserViewModel userModel)
        {
            string filePath = Path.Combine(FileServer.Users, $"{userModel.Identifier}.json");

            if (userModel.FullName != "Администратор" && File.Exists(filePath))
            {
                File.Delete(filePath);
                Users.Remove(userModel);
            }
        }
        void changeUserModel(UserViewModel userModel)
        {
            _dialogService.OpenWindowChangeUser(Users, userModel);
        }
    }
}
