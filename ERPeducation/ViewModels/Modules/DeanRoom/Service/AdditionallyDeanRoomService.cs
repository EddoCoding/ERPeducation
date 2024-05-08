using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ERPeducation.Views.DeanRoom.WindowApplicants;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Service
{
    public class AdditionallyDeanRoomService : IAdditionallyDeanRoom
    {
        public void OpenWindowApplicants()
        {
            ApplicantsWindow applicantsWindow = new ApplicantsWindow();
            applicantsWindow.DataContext = new ApplicantViewModel(new ApplicantDirectionRepository(), applicantsWindow.Close);
            applicantsWindow.ShowDialog();
        }
    }
}