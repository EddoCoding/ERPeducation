using ERPeducation.Common.Interface;
using ERPeducation.Common.Interface.DialogPersonal;
using ERPeducation.Models;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.Administration
{
    public class AdministrationUserViewModel : ReactiveObject
    {
        public string TextSearch { get; set; }

        public ObservableCollection<UserModel> Users { get; set; }

        public ReactiveCommand<Unit, Unit> AddUser { get; set; }
        public ReactiveCommand<Unit, Unit> SearchCommand { get; set; }


        IDialogService _dialogService;
        public AdministrationUserViewModel(IDialogService dialogService, IJSONService jsonService)
        {
            _dialogService = dialogService;

            Users = new ObservableCollection<UserModel>();

            jsonService.GetUserFileJson(Users);

            InitializingCommands();
        }

        void InitializingCommands()
        {
            AddUser = ReactiveCommand.Create(() =>
            {
                _dialogService.OpenWindowAddUser(Users);
            });

            SearchCommand = ReactiveCommand.Create(() =>
            {
                MessageBox.Show("Команда не реализована", "Заголовок");
            });
        }
    }
}
