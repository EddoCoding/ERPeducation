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


        public ReactiveCommand<Unit, Unit> AddEnrolleeCommand { get; set; }
        public ReactiveCommand<Unit, Unit> WithdrawStatementCommand { get; set; }
        public ReactiveCommand<Unit, Unit> FilterCommand { get; set; }

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
            AddEnrolleeCommand = ReactiveCommand.Create(() =>
            {
                data.TabItem.Add(new MainTabItem("Абитуриент", _userControlService.GetUserControlEnrollee(Enrollees)));
            });
            WithdrawStatementCommand = ReactiveCommand.Create(() => 
            { 
                MessageBox.Show("Метод не реализован", "Сообщение", MessageBoxButton.OK); 
            });
            FilterCommand = ReactiveCommand.Create(() => 
            { 
                MessageBox.Show("Метод не реализован", "Сообщение", MessageBoxButton.OK); 
            });
        }
    }
}