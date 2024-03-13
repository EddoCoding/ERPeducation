using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Interface.DialogPersonal;
using ERPeducation.Common.Validator;
using ERPeducation.Models;
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


        IDialogService _dialogService;
        IValidation _validation;
        IJSONService _jsonService;
        IDirectoryFile _directoryFile;
        public AuthorizationViewModel(IDialogService dialogService, IValidation validation, 
            IJSONService jsonService, IDirectoryFile directoryFile, Action closeWindow)
        {
            _dialogService = dialogService;
            _validation = validation;
            _jsonService = jsonService;
            _directoryFile = directoryFile;

            InitializingCommands();

            this.closeWindow = closeWindow;
        }

        void InitializingCommands()
        {
            GetFodlerPath = ReactiveCommand.Create(() =>
            {
                Path = _dialogService.OpenPathDialog();
            });

            CreateBase = ReactiveCommand.Create(() =>
            {
                Path = _directoryFile.CreateBase();
            });

            EnterBase = ReactiveCommand.Create(() =>
            {
                if (_validation.Validation(Identifier))
                {
                    UserModel user = _jsonService.GetFileJson(System.IO.Path.Combine(FileServer.Users, $"{Identifier}.json"));
                    _dialogService.OpenMainWindow(user, closeWindow);
                }
            });
        }
    }
}