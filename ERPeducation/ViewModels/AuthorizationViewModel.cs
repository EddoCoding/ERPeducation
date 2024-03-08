using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Interface.DialogPersonal;
using ERPeducation.Common.Validator;
using ERPeducation.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using System.Text.Json;
using System.Windows;

namespace ERPeducation.ViewModels
{
    public class AuthorizationViewModel : ReactiveObject
    {
        [Reactive] public string Path { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;

        public ReactiveCommand<Unit, Unit> GetFodlerPath { get; set; }
        public ReactiveCommand<Unit, Unit> CreateBase { get; set; }
        public ReactiveCommand<Unit, Unit> EnterBase { get; set; }

        IDialogService _dialogService;
        IValidation _validation;
        IJSONService _jsonService;

        public AuthorizationViewModel(IDialogService dialogService, IValidation validation, IJSONService jsonService)
        {
            _dialogService = dialogService;
            _validation = validation;
            _jsonService = jsonService;

            GetFodlerPath = ReactiveCommand.Create(() => 
            { 
                Path = dialogService.OpenPathDialog(); 
            });

            CreateBase = ReactiveCommand.Create(() => 
            { 
                Path = dialogService.CreateBase(); 
            });

            EnterBase = ReactiveCommand.Create(() => 
            {
                if (validation.Validation(Identifier))
                {
                    UserModel user = _jsonService.GetFileJson(System.IO.Path.Combine(FileServer.Users, $"{Identifier}.json"));
                    _dialogService.OpenMainWindow(user);
                }
            });
        }
    }
}