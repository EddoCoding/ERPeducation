using ERPeducation.Common.Windows.WindowDeanRoom.Faculty;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ERPeducation.ViewModels.Modules.DeanRoom.Old.Services;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Old
{
    public class FacultyVM : ReactiveObject
    {
        public ObservableCollection<TreeViewFaculty> Faculties { get; set; }

        TreeViewFaculty selectedFaculty = new TreeViewFaculty("Выберете факультет");
        public TreeViewFaculty SelectedFaculty
        {
            get => selectedFaculty;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedFaculty, value);
                if (selectedFaculty != null) InitializingDepartments?.Invoke(this);
            }
        }

        ObservableCollection<TreeViewMain>? treeViewMain;

        public ReactiveCommand<Unit, Unit> AddFacultyCommand { get; set; }
        public ReactiveCommand<TreeViewFaculty, Unit> ChangeFacultyCommand { get; set; }
        public ReactiveCommand<TreeViewFaculty, Unit> DeleteFacultyCommand { get; set; }

        IFaculty _faculty;
        IEducationalService<TreeViewFaculty> _educationalService;
        public FacultyVM(IFaculty faculty, IEducationalService<TreeViewFaculty> educationalService, ObservableCollection<TreeViewMain>? treeViewMain)
        {
            _faculty = faculty;
            _educationalService = educationalService;
            this.treeViewMain = treeViewMain;

            Faculties = new ObservableCollection<TreeViewFaculty>();

            GetEducationalData();
        }

        public event Action<FacultyVM>? InitializingDepartments;

        void GetEducationalData()
        {
            Faculties.Clear();

        }
    }
}