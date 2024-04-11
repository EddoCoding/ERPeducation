using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.Common.Windows.WindowDeanRoom.Department
{
    public class DepartmentWindowVM
    {
        public string TextAddChange { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;

        TreeViewFaculty? treeViewFaculty;

        public ReactiveCommand<Unit, Unit> AddDepartmentCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }

        Action closeWindow;

        public DepartmentWindowVM() { }
        public DepartmentWindowVM(TreeViewFaculty treeViewFaculty, Action closeWindow)
        {
            this.treeViewFaculty = treeViewFaculty;
            this.closeWindow = closeWindow;

            AddDepartmentCommand = ReactiveCommand.Create(AddDepartment);
            CloseWindowCommand = ReactiveCommand.Create(Exit);
        }
        void AddDepartment()
        {
            treeViewFaculty.Items.Add(new TreeViewDepartment(DepartmentName));
            closeWindow();
        }
        void Exit() => closeWindow();
    }
}
