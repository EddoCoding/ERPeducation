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

            CreateDepartmentCommand = ReactiveCommand.Create(AddDepartment);
            ChangeDepartmentCommand = ReactiveCommand.Create<TreeViewDepartment>(department => ChangeDepartment(department));
            LiquidationDepartmentCommand = ReactiveCommand.Create<TreeViewDepartment>(department => LiquidationDepartment(department));
        }

        public event Action<DepartmentVM> InitializingGroups;

        void AddDepartment()
        {
            if (selectedFaculty != null)
            {
                treeViewMain = _educationalService.jsonService.DeserializeTreeViewMain();

                foreach (var main in treeViewMain)
                    foreach (var faculties in main.Items)
                        if (faculties.Title == selectedFaculty.Title)
                        {
                            _department.AddDepartment(faculties);

                            _educationalService.jsonService.CreateFacultyFileJson(FileServer.structPathFaculty, treeViewMain);

                            GetEducationalData();

                            return;
                        }
            }
        }
        void ChangeDepartment(TreeViewDepartment department)
        {
            treeViewMain = _educationalService.jsonService.DeserializeTreeViewMain();

            foreach (var main in treeViewMain)
                foreach (var faculty in main.Items)
                    foreach (var departments in faculty.Items)
                        if (departments.Title == department.Title)
                            _department.ChangeDepartment(departments);

            _educationalService.jsonService.CreateFacultyFileJson(FileServer.structPathFaculty, treeViewMain);

            GetEducationalData();
        }
        void LiquidationDepartment(TreeViewDepartment department)
        {
            treeViewMain = _educationalService.jsonService.DeserializeTreeViewMain();

            foreach (var main in treeViewMain)
                foreach (var faculty in main.Items)
                    for (int i = faculty.Items.Count - 1; i >= 0; i--)
                    {
                        var departments = faculty.Items[i];
                        if (departments.Title == department.Title)
                        {
                            faculty.Items.RemoveAt(i);
                            break;
                        }
                    }

            _educationalService.jsonService.CreateFacultyFileJson(FileServer.structPathFaculty, treeViewMain);

            GetEducationalData();
        }

        void GetEducationalData()
        {
            Departments.Clear();

            foreach (var department in _educationalService.GetEducationalData(selectedFaculty))
                Departments.Add(department);
        }

        public void SetSelectedFaculty(TreeViewFaculty treeViewFaculty) => selectedFaculty = treeViewFaculty;
    }
}
