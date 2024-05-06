using ERPeducation.Models.AdmissionCampaign.Directions.TestEGG;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Repositories;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Services
{
    public interface ITestService
    {
        void OpenWindowAddTest(IDirectionRepository directionRepository);
        void OpenWindowEditTest(TestEGEBase test);
        void OpenWindowAddEGG(IDirectionRepository directionRepository);
        void OpenWindowEditEGG(TestEGEBase test);
    }
}