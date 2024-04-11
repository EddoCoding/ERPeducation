using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;

namespace ERPeducation.Common.Windows.WindowDeanRoom.Faculty
{
    public interface IFaculty
    {
        void AddFaculty(TreeViewMain treeViewMain);
        void ChangeFaculty(TreeViewFaculty faculty);
    }
}