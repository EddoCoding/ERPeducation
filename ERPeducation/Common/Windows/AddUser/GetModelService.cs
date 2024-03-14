using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;

namespace ERPeducation.Common.Windows.AddUser
{
    public class GetModelService : IGetModel
    {
        IJSONService jSONService = new JSONService();

        public UserViewModel GetUserModel(string fullName, string identifier, bool rector, bool deanRoom,
            bool trainingDivision, bool teacher, bool admissionCampaign, bool administration)
        {
            jSONService.CreateFileJson(FileServer.Users, $"{identifier}.json", fullName, identifier, rector, deanRoom, 
                trainingDivision, teacher, admissionCampaign, administration);
            return new UserViewModel(fullName, identifier, rector, deanRoom, trainingDivision,
                teacher, admissionCampaign, administration);
        }
    }
}