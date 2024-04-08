using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.Administration.Struct.Faculty
{
    [JsonObject]
    public class TreeViewFaculty : TreeViewBaseClass
    {
        public ObservableCollection<TreeViewDepartment> Items { get; set; }

        public event Action<TreeViewFaculty>? OnDelete;

        public TreeViewFaculty(string title)
        {
            Title = title;
            Items = new ObservableCollection<TreeViewDepartment>();

            Items.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (TreeViewDepartment item in e.OldItems) item.OnDelete -= deleteTreeViewItem;
                if (e.NewItems != null) foreach (TreeViewDepartment item in e.NewItems) item.OnDelete += deleteTreeViewItem;
            };

            Add = ReactiveCommand.Create(() =>
            {
                Items.Add(new TreeViewDepartment("Кафедра"));
            });

            Del = ReactiveCommand.Create(() =>
            {
                OnDelete?.Invoke(this);
            });
        }

        void deleteTreeViewItem(TreeViewDepartment group) => Items.Remove(group);
    }
}
