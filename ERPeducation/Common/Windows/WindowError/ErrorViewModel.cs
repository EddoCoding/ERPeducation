using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.Common.Windows.WindowError
{
    public class ErrorViewModel : ReactiveObject
    {
        public string TextError { get; set; }

        public ReactiveCommand<Unit, Unit> CloseWindow {  get; set; }

        public ErrorViewModel(string error, Action closeWindow)
        {
            TextError = error;

            CloseWindow = ReactiveCommand.Create(closeWindow);
        }
    }
}