using ERPeducation.Common.Interface;
using ERPeducation.Models;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class AdmissionCampaignViewModel : ReactiveObject
    {
        public ObservableCollection<EnrolleeViewModel> Enrollees { get; set; }
        MainTabControl<MainTabItem> data;

        public ReactiveCommand<Unit, Unit> AddChangeEnrolleeCommand { get; set; }
        public ReactiveCommand<Unit, Unit> SearchCommand { get; set; }
        public ReactiveCommand<Unit, Unit> SearchSettingCommand { get; set; }

        IUserControlService _userControlService;
        public AdmissionCampaignViewModel(IUserControlService userControlService, MainTabControl<MainTabItem> data)
        {
            _userControlService = userControlService;
            this.data = data;
            Enrollees = new ObservableCollection<EnrolleeViewModel>();

            InitializingCommands();
        }

        void InitializingCommands()
        {
            AddChangeEnrolleeCommand = ReactiveCommand.Create(() =>
            {
                data.TabItem.Add(new MainTabItem("Абитуриент", _userControlService.GetUserControlEnrollee(Enrollees)));
            });

            SearchCommand = ReactiveCommand.Create(() =>
            {
                MessageBox.Show("Метод не реализован", "Заголовок");
            });

            SearchSettingCommand = ReactiveCommand.Create(() =>
            {
                MessageBox.Show("Метод не реализован", "Заголовок");
            });
        }
    }
}