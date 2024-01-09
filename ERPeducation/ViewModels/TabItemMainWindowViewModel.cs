using ERPeducation.Common.Command;
using System;
using System.Windows.Input;

namespace ERPeducation.ViewModels
{
    public class TabItemMainWindowViewModel
    {
        public string? Title { get; set; }
        public object? Content { get; set; }

        public event Action<TabItemMainWindowViewModel>? OnClose;
        public ICommand CloseCommand { get; }
        void Close(object parameter) => OnClose?.Invoke(this);

        public TabItemMainWindowViewModel(string? title, object? content = default)
        {
            (Title, Content) = (title, content);
            CloseCommand = new MyCommand(Close);
        }
    }
}
