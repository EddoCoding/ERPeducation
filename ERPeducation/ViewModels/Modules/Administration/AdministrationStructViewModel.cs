using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Interface.DialogPersonal;
using ERPeducation.Common.Services;
using ERPeducation.Models.Administration;
using ERPeducation.ViewModels.Modules.Administration.Struct;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Reactive;
using System.Text.Json;

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

        public ObservableCollection<TreeViewLvlOne> TreeViewEducationCollection { get; set; } //Дерево образования

        #endregion
        #region Команды
        public ReactiveCommand<Unit, Unit> AddFacultyCommand { get; private set; }
        public ReactiveCommand<Unit, Unit> ConfigureFacultyCommand { get; private set; }
        public ReactiveCommand<Unit, Unit> ConfigureEducationCommand { get; private set; }
        #endregion

        IDialogService _dialogService;
        IDialogError _dialogError;
        IFileService _fileService;
        IJSONService _jsonService;
        public AdministrationStructViewModel(IDialogService dialogService, IDialogError dialogError, IFileService fileService, IJSONService jsonService)
        {
            _dialogService = dialogService;
            _dialogError = dialogError;
            _fileService = fileService;
            _jsonService = jsonService;

            #region Структура Факультетов
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
            #endregion
            #region Структура Образования
            TreeViewEducationCollection = new ObservableCollection<TreeViewLvlOne>();

            _jsonService.GetTreeViewLvlItem(TreeViewEducationCollection);

            ConfigureEducationCommand = ReactiveCommand.Create(() =>
            {
                File.WriteAllText(StaticBD.structPathEducation, JsonSerializer.Serialize(TreeViewEducationCollection));
            });
            #endregion
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