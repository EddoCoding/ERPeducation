using ERPeducation.Models.AdmissionCampaign.Directions.TestEGG;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions.EGGVM;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions.TestVM;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Repositories;
using ERPeducation.Views.AdmissionCampaign.WindowDirections.WindowEGG;
using ERPeducation.Views.AdmissionCampaign.WindowDirections.WindowTests;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Services
{
    public class TestService : ITestService
    {
        public void OpenWindowAddTest(IDirectionRepository directionRepository)
        {
            AddTestWindow addTestWindow = new AddTestWindow();
            addTestWindow.DataContext = new AddTestViewModel(directionRepository, addTestWindow.Close);
            addTestWindow.ShowDialog();
        }   //Открытие окна добавления испытания
        public void OpenWindowEditTest(TestEGEBase test)
        {
            EditTestWindow editTestWindow = new EditTestWindow();
            editTestWindow.DataContext = new EditTestViewModel(test, editTestWindow.Close);
            editTestWindow.ShowDialog();
        }                          //Открытие окна изменения испытания

        public void OpenWindowAddEGG(IDirectionRepository directionRepository)
        {
            AddEGGWindow addEGGWindow = new AddEGGWindow();
            addEGGWindow.DataContext = new AddEGEViewModel(directionRepository, addEGGWindow.Close);
            addEGGWindow.ShowDialog();
        }    //Открытие окна добавления испытания
        public void OpenWindowEditEGG(TestEGEBase ege)
        {
            EditEGEWindow editEGEWindow = new EditEGEWindow();
            editEGEWindow.DataContext = new EditEGEViewModel(ege, editEGEWindow.Close);
            editEGEWindow.ShowDialog();

        }                           //Открытие окна изменения ЕГЭ
    }
}