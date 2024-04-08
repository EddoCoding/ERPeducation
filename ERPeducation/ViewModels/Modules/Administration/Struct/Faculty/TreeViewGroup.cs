using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.Administration.Struct.Faculty
{
    [JsonObject]
    public class TreeViewGroup
    {
        public string Title { get; set; }
        public ObservableCollection<TreeViewStudent> Items { get; set; }

        public TreeViewGroup(string title)
        {
            Title = title;
            Items = new ObservableCollection<TreeViewStudent>();
        }
    }
}
