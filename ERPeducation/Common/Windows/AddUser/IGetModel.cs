namespace ERPeducation.Common.Windows.AddUser
{
    public interface IGetModel
    {
        UserViewModel GetUserModel(string fullName, string identifier, bool reactor, bool DeanRoom,
            bool trainingDivision, bool teacher, bool admissionCampaign, bool administration);
    }
}
