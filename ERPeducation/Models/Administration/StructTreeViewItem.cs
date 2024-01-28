using ERPeducation.Common.Interface;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive;

namespace ERPeducation.Models.Administration
{
    public class StructTreeViewItem : ReactiveObject
    {
        public string? Header { get; set; }
        [Reactive] public string Department { get; set; }
        [Reactive] public int DepartmentWidth { get; set; }

        public ObservableCollection<DepartmentTreeViewItem> Items { get; set; }

        public event Action<StructTreeViewItem>? OnDelete;
        public ReactiveCommand<Unit, Unit> DeleteTreeViewItemCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AddTreeViewItemCommand { get; set; }
        void Delete() => OnDelete?.Invoke(this);

        IFileService _fileService;
        public StructTreeViewItem(IFileService fileService)
        { 
            _fileService = fileService;

            Items = new ObservableCollection<DepartmentTreeViewItem>();
            DepartmentWidth = 0;
            DeleteTreeViewItemCommand = ReactiveCommand.Create(Delete);
            AddTreeViewItemCommand = ReactiveCommand.Create(addItem);

            Items.CollectionChanged += (object? sender, NotifyCollectionChangedEventArgs e) =>
            {
                if (e.OldItems != null) foreach (DepartmentTreeViewItem item in e.OldItems) item.OnDelete -= deleteTreeViewItem;
                if (e.NewItems != null) foreach (DepartmentTreeViewItem item in e.NewItems) item.OnDelete += deleteTreeViewItem;
            };
        }

        #region Методы
        void addItem()
        {
            if (DepartmentWidth == 0) DepartmentWidth = 300;
            else if (DepartmentWidth == 300 && !string.IsNullOrWhiteSpace(Department))
            {
                Items.Add(new DepartmentTreeViewItem()
                {
                    Header = $"--- {Department}"
                });
                Department = string.Empty;
                DepartmentWidth = 0;
            }
            else DepartmentWidth = 0;
        }
        void deleteTreeViewItem(DepartmentTreeViewItem treeViewItem)
        {
            _fileService.DeleteTreeViewItem(treeViewItem);
            Items.Remove(treeViewItem);
        }
        #endregion
    }
}