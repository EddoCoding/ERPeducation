using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.ViewModels.Modules.Administration.Struct.Education;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using System.Text.Json;

namespace ERPeducation.ViewModels.Modules.Administration
{
    public class AdministrationStructViewModel : ReactiveObject
    {
        public ObservableCollection<TreeViewFacultyItemOne> TreeViewFacultyCollection { get; set; } //Дерево факультетов
        public ObservableCollection<TreeViewLvlOne> TreeViewEducationCollection { get; set; } //Дерево образования

        public ReactiveCommand<Unit, Unit> ConfigureFacultyCommand { get; private set; }
        public ReactiveCommand<Unit, Unit> ConfigureEducationCommand { get; private set; }

        IJSONService _jsonService;
        public AdministrationStructViewModel(IJSONService jsonService)
        {
            _jsonService = jsonService;

            #region Структура Факультетов
            TreeViewFacultyCollection = new ObservableCollection<TreeViewFacultyItemOne>();

            _jsonService.GetTreeViewFacultyItem(TreeViewFacultyCollection);

            ConfigureFacultyCommand = ReactiveCommand.Create(() =>
            {
                File.WriteAllText(StaticBD.structPathFaculty, JsonSerializer.Serialize(TreeViewFacultyCollection));
            });
            #endregion

            #region Структура Образования
            TreeViewEducationCollection = new ObservableCollection<TreeViewLvlOne>();

            _jsonService.GetTreeViewEducationItem(TreeViewEducationCollection);

            ConfigureEducationCommand = ReactiveCommand.Create(() =>
            {
                File.WriteAllText(StaticBD.structPathEducation, JsonSerializer.Serialize(TreeViewEducationCollection));
            });
            #endregion
        }
        #region Методы
        //void AddFaculty()
        //{
        //    if (FacultyWidth == 0) FacultyWidth = 300;
        //    else if (FacultyWidth == 300 && !string.IsNullOrWhiteSpace(Faculty))
        //    {
        //        TreeViewItems.Add(new StructTreeViewItem(new FileService()) { Header = Faculty });
        //        Faculty = string.Empty;
        //        FacultyWidth = 0;
        //    }
        //    else FacultyWidth = 0;
        //}
        //void deleteTreeViewItem(StructTreeViewItem treeViewItem)
        //{
        //    this.treeViewItem = treeViewItem;
        //    _dialogError.OpenNotification(this);
        //}
        //public void DeleteTreeViewItem()
        //{
        //    _fileService.DeleteTreeViewItem(treeViewItem);
        //    TreeViewItems.Remove(treeViewItem);
        //}
        #endregion
    }
}