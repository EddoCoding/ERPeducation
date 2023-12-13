using ERPeducation.Interface;
using System.Collections.ObjectModel;

namespace ERPeducation.Common
{
    public class BaseDataForModules<T> : INPC
    {
        public string[] DataForTabs { get; set; }
        private ObservableCollection<T>? tabItem;
        public ObservableCollection<T> TabItem
        {
            get => tabItem;
            set
            {
                tabItem = value;
                OnPropertyChanged(nameof(TabItem));
            }
        }
    }
}