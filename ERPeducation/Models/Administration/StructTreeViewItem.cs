using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.Models.Administration
{
    public class StructTreeViewItem : ReactiveObject
    {
        public string? Header { get; set; }
        public ObservableCollection<string> Items { get; set; }


        public event Action<StructTreeViewItem>? OnDelete;
        public ReactiveCommand<Unit, Unit> DeleteTreeViewItemCommand { get; set; }
        void Delete() => OnDelete?.Invoke(this);

        public StructTreeViewItem(string? header) 
        { 
            Header = header;
            Items = new ObservableCollection<string>();
            DeleteTreeViewItemCommand = ReactiveCommand.Create(Delete);
        }
    }
}