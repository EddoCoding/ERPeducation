using ERPeducation.Common.Interface;
using ERPeducation.Models;
using ERPeducation.ViewModels;
using ERPeducation.ViewModels.Modules.Administration;
using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ERPeducation.ViewModels.Modules.DeanRoom.Service;
using ERPeducation.ViewModels.Modules.TrainingDivision;
using ERPeducation.Views;
using ERPeducation.Views.Administration;
using ERPeducation.Views.AdmissionCampaign;
using ERPeducation.Views.DeanRoom;
using System.Windows.Controls;

namespace ERPeducation.Common.Services
{
    public class UserControlService : IUserControlService
    {




        public UserControl GetModuleDeanRoom() => new DeanRoom() { DataContext = new DeanRoomViewModel(new DeanRoomService(), new DeanRoomRepository()) };     // -- ВКЛАДКА МОДУЛЯ ДЕКАНАТ --





        //ВКЛАДКА МОДУЛЯ УЧЕБНЫЙ ОТДЕЛ
        public UserControl GetModuleTrainingDivision() =>
            new ModuleTrainingDivision() { DataContext = new TrainingDivisionViewModel(new SyllabusService()) };

        //ВКЛАДКА МОДУЛЯ ПРИЕМНАЯ КАМПАНИЯ
        public UserControl GetModuleAdmissionCampaign(MainTabControl<MainTabItem> mainTabControls)
        {
            AdmissionCampaignView view = new();
            view.DataContext = new AdmissionCampaignViewModel(new AdmissionRepository(), mainTabControls);
            return view;
        }


        //ВКЛАДКА МОДУЛЯ АДМИНИСТРИРОВАНИЕ
        public UserControl GetModuleAdministration() => 
            new ModuleAdministration() { DataContext = new AdministrationViewModel(this) };

        public UserControl GetUserControlForAdministrationView() =>
            new AdministrationUsersView() { DataContext = new AdministrationUserViewModel(new DialogService(), new JSONService()) };
        public UserControl GetUserControlForAdministrationStruct() => 
            new AdministrationStructView() { DataContext = new AdministrationStructViewModel(new JSONService()) };
    }
}