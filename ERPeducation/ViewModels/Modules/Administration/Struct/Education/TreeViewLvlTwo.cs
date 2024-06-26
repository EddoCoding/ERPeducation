﻿using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.Administration.Struct.Education
{
    [JsonObject]
    public class TreeViewLvlTwo : TreeViewBaseClass
    {
        public ObservableCollection<TreeViewLvlThree> Items { get; set; }

        public event Action<TreeViewLvlTwo>? OnDelete;

        public TreeViewLvlTwo(string title)
        {
            Title = title;
            Items = new ObservableCollection<TreeViewLvlThree>();

            Items.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (TreeViewLvlThree item in e.OldItems) item.OnDelete -= deleteTreeViewItem;
                if (e.NewItems != null) foreach (TreeViewLvlThree item in e.NewItems) item.OnDelete += deleteTreeViewItem;
            };

            Add = ReactiveCommand.Create(() =>
            {
                Items.Add(new TreeViewLvlThree("Направление подготовки"));
            });

            Del = ReactiveCommand.Create(() =>
            {
                OnDelete?.Invoke(this);
            });

            void deleteTreeViewItem(TreeViewLvlThree treeViewItemThree) => Items.Remove(treeViewItemThree);
        }
    }
}
