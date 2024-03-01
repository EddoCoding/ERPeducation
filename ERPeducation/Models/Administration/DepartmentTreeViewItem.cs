using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.Models.Administration
{
    public class DepartmentTreeViewItem : ReactiveObject //УДАЛИТЬ И ПЕРЕДЕЛАТЬ КЛАСС ДЕРЕВА КАК STRUCT EDUCATION
    {
        public string? Header { get; set; }

        public event Action<DepartmentTreeViewItem>? OnDelete;
        public ReactiveCommand<Unit, Unit> DeleteTreeViewItemCommand { get; set; }
        void Delete() => OnDelete?.Invoke(this);

        public DepartmentTreeViewItem() => DeleteTreeViewItemCommand = ReactiveCommand.Create(Delete);
    }
}