using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Repositories;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Services
{
    public interface ITestService
    {
        void OpenWindowAddTest(IDirectionRepository directionRepository);
        void OpenWindowEditTest(Test test);
    }
}