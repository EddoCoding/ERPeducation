﻿using Newtonsoft.Json;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.Administration.Struct.Education
{
    [JsonObject]
    public class TreeViewLvlOne : TreeViewBaseClass
    {
        public ObservableCollection<TreeViewLvlTwo> Items { get; set; }

        public TreeViewLvlOne(string title)
        {
            Title = title;
            Items = new ObservableCollection<TreeViewLvlTwo>();

            Items.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (TreeViewLvlTwo item in e.OldItems) item.OnDelete -= deleteTreeViewItem;
                if (e.NewItems != null) foreach (TreeViewLvlTwo item in e.NewItems) item.OnDelete += deleteTreeViewItem;
            };

            Add = ReactiveCommand.Create(() =>
            {
                Items.Add(new TreeViewLvlTwo("Уровень"));
            });

            void deleteTreeViewItem(TreeViewLvlTwo treeViewItemTwo) => Items.Remove(treeViewItemTwo);
        }
    }
}