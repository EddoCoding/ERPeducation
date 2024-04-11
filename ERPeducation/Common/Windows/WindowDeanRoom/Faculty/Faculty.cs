using ERPeducation.Common.Windows.WindowDeanRoom.Department;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ERPeducation.ViewModels.Modules.DeanRoom;
using ReactiveUI;

namespace ERPeducation.Common.Windows.WindowDeanRoom.Faculty
{
    public class Faculty : IFaculty
    {
        public void AddFaculty(TreeViewMain treeViewMain)
        {
            FacultyView view = new FacultyView();
            view.DataContext = new FacultyWindowVM(treeViewMain, view.Close) { TextAddChange = "Добавить" };
            view.ShowDialog();
        }

        public void ChangeFaculty(TreeViewFaculty faculty)
        {
            FacultyView view = new FacultyView();
            var vm = new FacultyWindowVM()
            {
                FacultyName = faculty.Title,
                CloseWindowCommand = ReactiveCommand.Create(view.Close),
                TextAddChange = "Изменить"
            };
            vm.AddFacultyCommand = ReactiveCommand.Create(() =>
            {
                faculty.Title = vm.FacultyName;
                view.Close();
            });
            view.DataContext = vm;
            view.ShowDialog();
        }
    }
}