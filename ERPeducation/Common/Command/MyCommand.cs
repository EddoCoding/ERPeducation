using System;
using System.Windows.Input;

namespace ERPeducation.Common.Command
{
    public class MyCommand : ICommand
    {
        private readonly Action<object> execute;
        public event EventHandler? CanExecuteChanged;

        public MyCommand(Action<object> execute) => this.execute = execute;

        public bool CanExecute(object? parameter) => true;
        public void Execute(object? parameter) => execute(parameter);
    }
}
