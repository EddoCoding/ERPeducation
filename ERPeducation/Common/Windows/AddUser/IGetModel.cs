using ERPeducation.Models;

namespace ERPeducation.Common.Windows.AddUser
{
    public interface IGetModel
    {
        UserModel GetUserModel(string fullName, string identifier, bool reactor, bool DeanRoom,
            bool trainingDivision, bool teacher, bool admissionCampaign, bool administration);
    }
}
