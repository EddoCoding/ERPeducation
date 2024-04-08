using Newtonsoft.Json;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.Administration.Struct.Faculty
{
    [JsonObject]
    public class TreeViewMain : TreeViewBaseClass
    {
        public ObservableCollection<TreeViewFaculty> Items { get; set; }

        public TreeViewMain(string title)
        {
            Title = title;
            Items = new ObservableCollection<TreeViewFaculty>();

            Items.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (TreeViewFaculty item in e.OldItems) item.OnDelete -= deleteTreeViewItem;
                if (e.NewItems != null) foreach (TreeViewFaculty item in e.NewItems) item.OnDelete += deleteTreeViewItem;
            };

            Add = ReactiveCommand.Create(() =>
            {
                Items.Add(new TreeViewFaculty("Факультет"));
            });

            void deleteTreeViewItem(TreeViewFaculty department) => Items.Remove(department);
        }
    }
}
