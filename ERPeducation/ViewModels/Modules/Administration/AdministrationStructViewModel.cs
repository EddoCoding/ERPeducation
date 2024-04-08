using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.ViewModels.Modules.Administration.Struct.Education;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.Administration
{
    public class AdministrationStructViewModel : ReactiveObject
    {
        public ObservableCollection<TreeViewMain> TreeViewFacultyCollection { get; set; } //Дерево факультетов
        public ObservableCollection<TreeViewLvlOne> TreeViewEducationCollection { get; set; } //Дерево образования
        public ObservableCollection<object> TreeViewSpaceCollection { get; set; } //Дерево пространств - СДЕЛАТЬ!!!

        public ReactiveCommand<Unit, Unit> ConfigureFacultyCommand { get; private set; }
        public ReactiveCommand<Unit, Unit> ConfigureEducationCommand { get; private set; }

        IJSONService _jsonService;
        public AdministrationStructViewModel(IJSONService jsonService)
        {
            _jsonService = jsonService;

            InitializingCommands();

            #region Структура Факультетов
            TreeViewFacultyCollection = new ObservableCollection<TreeViewMain>();
            _jsonService.GetTreeViewFacultyItem(TreeViewFacultyCollection);
            #endregion
            #region Структура Образования
            TreeViewEducationCollection = new ObservableCollection<TreeViewLvlOne>();
            _jsonService.GetTreeViewEducationItem(TreeViewEducationCollection);
            #endregion

            //СДЕЛАТЬ
            #region Пространства

            #endregion
            //СДЕЛАТЬ

        }

        void InitializingCommands()
        {
            ConfigureFacultyCommand = ReactiveCommand.Create(() =>
            {
                _jsonService.CreateFacultyFileJson(FileServer.structPathFaculty, TreeViewFacultyCollection);
            });
            ConfigureEducationCommand = ReactiveCommand.Create(() =>
            {
                _jsonService.CreateEducationFileJson(FileServer.structPathEducation, TreeViewEducationCollection);
            });
        }
    }
}