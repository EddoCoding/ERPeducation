using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions.TestVM;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Repositories;
using ERPeducation.Views.AdmissionCampaign.WindowDirections.WindowTests;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Services
{
    public class TestService : ITestService
    {
        public void OpenWindowAddTest(IDirectionRepository directionRepository)  //Открытие окна добавления испытания
        {
            AddTestWindow addTestWindow = new AddTestWindow();
            addTestWindow.DataContext = new AddTestViewModel(directionRepository, addTestWindow.Close);
            addTestWindow.ShowDialog();
        }
        public void OpenWindowEditTest(Test test) //Открытие окна изменения испытания
        {
            EditTestWindow editTestWindow = new EditTestWindow();
            editTestWindow.DataContext = new EditTestViewModel(test, editTestWindow.Close);
            editTestWindow.ShowDialog();
        }
    }
}