using ERPeducation.Models.Administration;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive;
using System.Windows;
using System.Windows.Media;

namespace ERPeducation.ViewModels.Modules.Administration
{
    public class AdministrationStructViewModel : ReactiveObject
    {
        public ObservableCollection<StructTreeViewItem> TreeViewItems { get; set; }

        [Reactive] public string Faculty { get; set; }
        [Reactive] public int FacultyWidth { get; set; }

        public ReactiveCommand<Unit, Unit> AddFacultyCommand { get; set; }
        public ReactiveCommand<Unit, Unit> command2 { get; set; }

        public AdministrationStructViewModel()
        {
            TreeViewItems = new ObservableCollection<StructTreeViewItem>();
            FacultyWidth = 0;

            AddFacultyCommand = ReactiveCommand.Create(AddFaculty);
            command2 = ReactiveCommand.Create(Check);

            TreeViewItems.CollectionChanged += (object? sender, NotifyCollectionChangedEventArgs e) =>
            {
                if (e.OldItems != null) foreach (StructTreeViewItem item in e.OldItems) item.OnDelete -= deleteTreeViewItem;
                if (e.NewItems != null) foreach (StructTreeViewItem item in e.NewItems) item.OnDelete += deleteTreeViewItem;
            };

        }

        void AddFaculty()
        {
            if (FacultyWidth == 0) FacultyWidth = 300;
            else if (FacultyWidth == 300 && !string.IsNullOrWhiteSpace(Faculty))
            {
                TreeViewItems.Add(new StructTreeViewItem($"--- {Faculty}"));
                Faculty = string.Empty;
                FacultyWidth = 0;
            }
        }
        void Check()
        {
            for (int i = 0; i < TreeViewItems.Count; i++)
            {
                MessageBox.Show($"{TreeViewItems[i].Header}\n" +
                                $"{TreeViewItems[i].Items.Count}");
            }
        }
        void deleteTreeViewItem(StructTreeViewItem treeViewItem) => TreeViewItems.Remove(treeViewItem);
    }
}