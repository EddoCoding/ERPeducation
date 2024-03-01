using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.Administration.Struct.Faculty
{
    public class TreeViewFacultyItemTwo : TreeViewFacultyBaseClass
    {
        public ObservableCollection<TreeViewFacultyItemThree> Items { get; set; }

        public event Action<TreeViewFacultyItemTwo>? OnDelete;

        public TreeViewFacultyItemTwo(string title)
        {
            Title = title;
            Items = new ObservableCollection<TreeViewFacultyItemThree>();

            Items.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (TreeViewFacultyItemThree item in e.OldItems) item.OnDelete -= deleteTreeViewItem;
                if (e.NewItems != null) foreach (TreeViewFacultyItemThree item in e.NewItems) item.OnDelete += deleteTreeViewItem;
            };

            Add = ReactiveCommand.Create(() =>
            {
                Items.Add(new TreeViewFacultyItemThree("Кафедра"));
            });

            Del = ReactiveCommand.Create(() =>
            {
                OnDelete?.Invoke(this);
            });
        }

        void deleteTreeViewItem(TreeViewFacultyItemThree treeViewItemThree) => Items.Remove(treeViewItemThree);
    }
}
