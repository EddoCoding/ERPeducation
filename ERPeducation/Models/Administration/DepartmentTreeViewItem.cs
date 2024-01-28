using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.Models.Administration
{
    public class DepartmentTreeViewItem : ReactiveObject
    {
        public string? Header { get; set; }

        public event Action<DepartmentTreeViewItem>? OnDelete;
        public ReactiveCommand<Unit, Unit> DeleteTreeViewItemCommand { get; set; }
        void Delete() => OnDelete?.Invoke(this);

        public DepartmentTreeViewItem() => DeleteTreeViewItemCommand = ReactiveCommand.Create(Delete);
    }
}