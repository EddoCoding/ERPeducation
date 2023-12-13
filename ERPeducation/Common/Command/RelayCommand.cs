using System;
using System.Windows.Input;

namespace ERPeducation.Command
{
    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute) => this.execute = execute;

        public bool CanExecute(object parameter) => true;
        public void Execute(object? parameter) => execute();
    }
}
