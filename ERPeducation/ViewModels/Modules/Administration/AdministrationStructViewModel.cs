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
        }
    }
}