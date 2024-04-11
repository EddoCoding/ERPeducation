using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ReactiveUI;

namespace ERPeducation.Common.Windows.WindowDeanRoom.Department
{
    public class Department : IDepartment
    {
        public void AddDepartment(TreeViewFaculty treeViewFaculty)
        {
            DepartmentView view = new DepartmentView();
            view.DataContext = new DepartmentWindowVM(treeViewFaculty, view.Close) { TextAddChange = "Добавить" };
            view.ShowDialog();
        }

        public void ChangeDepartment(TreeViewDepartment department)
        {
            DepartmentView view = new DepartmentView();
            var vm = new DepartmentWindowVM()
            {
                DepartmentName = department.Title,
                CloseWindowCommand = ReactiveCommand.Create(view.Close),
                TextAddChange = "Изменить"
            };
            vm.AddDepartmentCommand = ReactiveCommand.Create(() =>
            {
                department.Title = vm.DepartmentName;
                view.Close();
            });
            view.DataContext = vm;
            view.ShowDialog();
        }
    }
}