using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;

namespace ERPeducation.Common.Windows.WindowDeanRoom.Group
{
    public interface IGroup
    {
        void AddGroup(TreeViewDepartment treeViewDepartment);
        void ChangeGroup(TreeViewGroup group);
    }
}