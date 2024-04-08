using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.Administration.Struct.Faculty
{
    [JsonObject]
    public class TreeViewDepartment : TreeViewBaseClass
    {
        public ObservableCollection<TreeViewGroup> Items { get; set; }
        public event Action<TreeViewDepartment>? OnDelete;

        public TreeViewDepartment(string title)
        {
            Title = title;
            Items = new ObservableCollection<TreeViewGroup>();

            Del = ReactiveCommand.Create(() =>
            {
                OnDelete?.Invoke(this);
            });
        }
    }
}
