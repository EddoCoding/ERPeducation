using ERPeducation.Interface;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;

namespace ERPeducation.Common
{
    public class BaseDataForModules<T> : ReactiveObject
    {
        public string[] DataForTabs { get; set; }
        [Reactive] public ObservableCollection<T> TabItem { get; set; }
    }
}