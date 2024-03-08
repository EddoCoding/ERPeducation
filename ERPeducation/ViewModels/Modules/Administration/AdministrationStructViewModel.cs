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
        public ObservableCollection<object> TreeViewSpaceCollection { get; set; } //Дерево пространств - СДЕЛАТЬ!!!

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
                File.WriteAllText(FileServer.structPathFaculty, JsonSerializer.Serialize(TreeViewFacultyCollection));
            });
            #endregion

            #region Структура Образования
            TreeViewEducationCollection = new ObservableCollection<TreeViewLvlOne>();

            _jsonService.GetTreeViewEducationItem(TreeViewEducationCollection);

            ConfigureEducationCommand = ReactiveCommand.Create(() =>
            {
                File.WriteAllText(FileServer.structPathEducation, JsonSerializer.Serialize(TreeViewEducationCollection));
            });
            #endregion

            //СДЕЛАТЬ
            #region Пространства

            #endregion
            //СДЕЛАТЬ
        }
    }
}