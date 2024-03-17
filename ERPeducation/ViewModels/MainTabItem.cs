using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels
{
    public class MainTabItem : ReactiveObject
    {
        public string? Title { get; set; }
        public object? Content { get; set; }

        public event Action<MainTabItem>? OnClose;
        public ReactiveCommand<Unit, Unit> CloseCommand { get; set; }
        void Close() => OnClose?.Invoke(this);

        public MainTabItem(string? title, object? content = default)
        {
            (Title, Content) = (title, content);
            CloseCommand = ReactiveCommand.Create(Close);
        }
    }
}