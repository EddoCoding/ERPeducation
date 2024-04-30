using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Interface.DialogPersonal;
using ERPeducation.Common.Validator;
using ERPeducation.Common.Windows.AddUser;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels
{
    public class AuthorizationViewModel : ReactiveObject
    {
        [Reactive] public string Path { get; set; }
        public string Identifier { get; set; } = string.Empty;

        public ReactiveCommand<Unit, Unit> GetFodlerPath { get; set; }
        public ReactiveCommand<Unit, Unit> CreateBase { get; set; }
        public ReactiveCommand<Unit, Unit> EnterBase { get; set; }

        Action closeWindow;

        public AuthorizationViewModel(IDialogService dialogService, IValidation validation, 
            IJSONService jsonService, IDirectoryFile directoryFile, Action closeWindow)
        {
            GetFodlerPath = ReactiveCommand.Create(() =>
            {
                Path = dialogService.OpenPathDialog();
            });
            CreateBase = ReactiveCommand.Create(() =>
            {
                Path = directoryFile.CreateBase();
            });
            EnterBase = ReactiveCommand.Create(() =>
            {
                if (validation.Validation(Identifier))
                {
                    UserViewModel user = jsonService.GetFileJson(System.IO.Path.Combine(FileServer.Users, $"{Identifier}.json"));
                    dialogService.OpenMainWindow(user, closeWindow);
                }
            });

            this.closeWindow = closeWindow;
        }
    }
}