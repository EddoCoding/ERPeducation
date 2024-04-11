using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;

namespace ERPeducation.Common.Windows.WindowDeanRoom.Student
{
    public interface IStudent
    {
        void AddStudent(TreeViewGroup treeViewStudent);
        void ChangeStudent(TreeViewStudent student);
    }
}