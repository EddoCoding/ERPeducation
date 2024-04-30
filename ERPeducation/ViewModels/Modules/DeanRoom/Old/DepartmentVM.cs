using ERPeducation.Common.BD;
using ERPeducation.Common.Windows.WindowDeanRoom.Department;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ERPeducation.ViewModels.Modules.DeanRoom.Old.Services;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Old
{
    public class DepartmentVM : ReactiveObject
    {
        public ObservableCollection<TreeViewDepartment> Departments { get; set; }

        TreeViewDepartment selectedDepartment;
        public TreeViewDepartment SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedDepartment, value);
                if (selectedDepartment != null)
                {
                    InitializingGroups?.Invoke(this);
                }
            }
        }

        ObservableCollection<TreeViewMain>? treeViewMain;

        TreeViewFaculty? selectedFaculty;

        public ReactiveCommand<Unit, Unit> CreateDepartmentCommand { get; set; }
        public ReactiveCommand<TreeViewDepartment, Unit> LiquidationDepartmentCommand { get; set; }
        public ReactiveCommand<TreeViewDepartment, Unit> ChangeDepartmentCommand { get; set; }


        IDepartment _department;
        IEducationalService<TreeViewDepartment> _educationalService;
        public DepartmentVM(IDepartment department, IEducationalService<TreeViewDepartment> educationalService, ObservableCollection<TreeViewMain>? treeViewMain)
        {
            _department = department;
            _educationalService = educationalService;
            this.treeViewMain = treeViewMain;

            Departments = new ObservableCollection<TreeViewDepartment>();
        }

        public event Action<DepartmentVM> InitializingGroups;

        public void SetSelectedFaculty(TreeViewFaculty treeViewFaculty) => selectedFaculty = treeViewFaculty;
    }
}
