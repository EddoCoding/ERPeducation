using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;

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
    }
}