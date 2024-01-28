using ERPeducation.Common.Interface;
using ERPeducation.Common.Interface.DialogPersonal;
using ERPeducation.Common.Services;
using ERPeducation.Models.Administration;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.Administration
{
    public class AdministrationStructViewModel : ReactiveObject
    {
        #region Визуальные свойства
        [Reactive] public int FacultyWidth { get; set; }
        #endregion
        #region Свойства контролов
        public ObservableCollection<StructTreeViewItem> TreeViewItems { get; set; } //Список факультетов с кафедрами
        StructTreeViewItem treeViewItem;
        [Reactive] public string Faculty { get; set; } //Строка для названия факультета

        public ObservableCollection<string> Level { get; set; }
        public ObservableCollection<string> Form { get; set; }
        public ObservableCollection<string> Direction { get; set; }
        #endregion
        #region Команды
        public ReactiveCommand<Unit, Unit> AddFacultyCommand { get; private set; }
        public ReactiveCommand<Unit, Unit> ConfigureFacultyCommand { get; private set; }

        public ReactiveCommand<Unit, Unit> AddLevel { get; private set; }
        public ReactiveCommand<Unit, Unit> DelLevel { get; private set; }
        public ReactiveCommand<Unit, Unit> AddForm { get; private set; }
        public ReactiveCommand<Unit, Unit> DelForm { get; private set; }
        public ReactiveCommand<Unit, Unit> AddDirection { get; private set; }
        public ReactiveCommand<Unit, Unit> DelDirection { get; private set; }
        public ReactiveCommand<Unit, Unit> ConfigureEducationCommand { get; private set; }
        #endregion

        IDialogService _dialogService;
        IDialogError _dialogError;
        IFileService _fileService;
        public AdministrationStructViewModel(IDialogService _dialogService, IDialogError dialogError, IFileService fileService)
        {
            _dialogError = dialogError;
            _fileService = fileService;

            TreeViewItems = new ObservableCollection<StructTreeViewItem>();
            TreeViewItems.CollectionChanged += (object? sender, NotifyCollectionChangedEventArgs e) =>
            {
                if (e.OldItems != null) foreach (StructTreeViewItem item in e.OldItems) item.OnDelete -= deleteTreeViewItem;
                if (e.NewItems != null) foreach (StructTreeViewItem item in e.NewItems) item.OnDelete += deleteTreeViewItem;
            };

            AddFacultyCommand = ReactiveCommand.Create(AddFaculty);
            ConfigureFacultyCommand = ReactiveCommand.Create(() => 
            {
                _fileService.ConfigureStruct(TreeViewItems);
            });
            fileService.GetFaculties(TreeViewItems);
            FacultyWidth = 0;

            Level = new ObservableCollection<string>();
            Form = new ObservableCollection<string>();
            Direction = new ObservableCollection<string>();

            AddLevel = ReactiveCommand.Create(() =>
            {
                _dialogService.OpenWindowStructEducation(Level, "Level");
            });
            DelLevel = ReactiveCommand.Create(() => { });

            AddForm = ReactiveCommand.Create(() => 
            {
                _dialogService.OpenWindowStructEducation(Form, "Form");
            });
            DelForm = ReactiveCommand.Create(() => { });
            
            AddDirection = ReactiveCommand.Create(() => 
            {
                _dialogService.OpenWindowStructEducation(Direction, "Direction");
            });
            DelDirection = ReactiveCommand.Create(() => { });
        }

        #region Методы
        void AddFaculty()
        {
            if (FacultyWidth == 0) FacultyWidth = 300;
            else if (FacultyWidth == 300 && !string.IsNullOrWhiteSpace(Faculty))
            {
                TreeViewItems.Add(new StructTreeViewItem(new FileService()) { Header = Faculty });
                Faculty = string.Empty;
                FacultyWidth = 0;
            }
            else FacultyWidth = 0;
        }
        void deleteTreeViewItem(StructTreeViewItem treeViewItem)
        {
            this.treeViewItem = treeViewItem;
            _dialogError.OpenNotification(this);
        }
        public void DeleteTreeViewItem()
        {
            _fileService.DeleteTreeViewItem(treeViewItem);
            TreeViewItems.Remove(treeViewItem);
        }
        #endregion
    }
}