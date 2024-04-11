using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;

namespace ERPeducation.Common.Windows.WindowDeanRoom.Department
{
    public interface IDepartment
    {
        void AddDepartment(TreeViewFaculty treeViewFaculty);
        void ChangeDepartment(TreeViewDepartment department);
    }
}