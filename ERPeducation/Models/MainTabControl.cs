using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;

namespace ERPeducation.Models
{
    public class MainTabControl<T> : ReactiveObject
    {
        [Reactive] public ObservableCollection<T> TabItem { get; set; }
    }
}