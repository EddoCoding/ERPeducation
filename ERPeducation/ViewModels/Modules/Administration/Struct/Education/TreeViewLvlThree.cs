using DynamicData;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ERPeducation.ViewModels.Modules.Administration.Struct.Education
{
    [JsonObject]
    public class TreeViewLvlThree : TreeViewBaseClass
    {
        public ObservableCollection<TreeViewLvlFour> Items { get; set; }

        public event Action<TreeViewLvlThree>? OnDelete;

        public TreeViewLvlThree(string title)
        {
            Title = title;

            Items = new ObservableCollection<TreeViewLvlFour>();

            Items.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (TreeViewLvlFour item in e.OldItems) item.OnDelete -= deleteTreeViewItem;
                if (e.NewItems != null) foreach (TreeViewLvlFour item in e.NewItems) item.OnDelete += deleteTreeViewItem;
            };

            Add = ReactiveCommand.Create(() =>
            {
                Items.Add(new TreeViewLvlFour("Форма обучения"));
            });
            Del = ReactiveCommand.Create(() =>
            {
                OnDelete?.Invoke(this);
            });
        }

        void deleteTreeViewItem(TreeViewLvlFour treeViewItemThree) => Items.Remove(treeViewItemThree);
    }
}
