using ERPeducation.Common.Windows.AddUser;
using ERPeducation.ViewModels.Modules.Administration.Struct.Education;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Interface
{
    public interface IJSONService
    {
        void CreateFacultyFileJson(string filePath, ObservableCollection<TreeViewFacultyItemOne> collection);
        void CreateEducationFileJson(string filePath, ObservableCollection<TreeViewLvlOne> collection);
        void GetTreeViewFacultyItem(ObservableCollection<TreeViewFacultyItemOne> treeViewCollection);
        void GetTreeViewEducationItem(ObservableCollection<TreeViewLvlOne> treeViewCollection);
        void CreateFileJson(string fileJson, string fileName, string fullname, string identifier,
            bool rectorAccess, bool deanRoom, bool trainingDivision, bool teacher, bool admissionCampaign, bool administration);
        UserViewModel GetFileJson(string filePath);
        void GetUserFileJson(ObservableCollection<UserViewModel> users);
        ObservableCollection<TreeViewLvlOne> TreeViewEducation();
        ObservableCollection<TreeViewFacultyItemOne> TreeViewFaculty();
    }
}
