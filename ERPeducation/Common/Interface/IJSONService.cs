using ERPeducation.ViewModels.Modules.Administration.Struct.Education;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Interface
{
    public interface IJSONService
    {
        public void GetTreeViewEducationItem(ObservableCollection<TreeViewLvlOne> treeViewCollection);
        public void GetTreeViewFacultyItem(ObservableCollection<TreeViewFacultyItemOne> treeViewCollection);
    }
}
