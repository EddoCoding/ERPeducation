using ERPeducation.Common.Windows.AddUser;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Interface
{
    public interface IJSONService
    {
        void CreateFileJson(string fileJson, string fileName, string fullname, string identifier,
            bool rectorAccess, bool deanRoom, bool trainingDivision, bool teacher, bool admissionCampaign, bool administration);
        UserViewModel GetFileJson(string filePath);
        void GetUserFileJson(ObservableCollection<UserViewModel> users);
    }
}
