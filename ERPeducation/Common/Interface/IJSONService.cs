using ERPeducation.Models;
using ERPeducation.ViewModels.Modules.Administration.Struct.Education;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace ERPeducation.Common.Interface
{
    public interface IJSONService
    {
        void GetTreeViewEducationItem(ObservableCollection<TreeViewLvlOne> treeViewCollection);
        void GetTreeViewFacultyItem(ObservableCollection<TreeViewFacultyItemOne> treeViewCollection);
        void CreateFileJson(string fileJson, string fileName, string fullname, string identifier,
            bool rectorAccess, bool deanRoom, bool trainingDivision, bool teacher, bool admissionCampaign, bool administration);
        UserModel GetFileJson(string filePath);
    }
}
