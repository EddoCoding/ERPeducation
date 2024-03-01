using ReactiveUI;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.Administration.Struct.Faculty
{
    public class TreeViewFacultyItemOne : TreeViewFacultyBaseClass
    {
        public ObservableCollection<TreeViewFacultyItemTwo> Items { get; set; }

        public TreeViewFacultyItemOne(string title)
        {
            Title = title;
            Items = new ObservableCollection<TreeViewFacultyItemTwo>();

            Items.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (TreeViewFacultyItemTwo item in e.OldItems) item.OnDelete -= deleteTreeViewItem;
                if (e.NewItems != null) foreach (TreeViewFacultyItemTwo item in e.NewItems) item.OnDelete += deleteTreeViewItem;
            };

            Add = ReactiveCommand.Create(() =>
            {
                Items.Add(new TreeViewFacultyItemTwo("Факультет"));
            });

            void deleteTreeViewItem(TreeViewFacultyItemTwo treeViewItemTwo) => Items.Remove(treeViewItemTwo);
        }
    }
}
