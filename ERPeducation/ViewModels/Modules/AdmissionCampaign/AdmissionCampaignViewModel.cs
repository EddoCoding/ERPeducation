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
        public ObservableCollection<AddChangeEnrolleeViewModel> Enrollees { get; set; }
        MainTabControl<MainTabItem> data;

        public ReactiveCommand<Unit, Unit> AddChangeEnrolleeCommand { get; set; }
        public ReactiveCommand<Unit, Unit> SearchCommand { get; set; }
        public ReactiveCommand<Unit, Unit> SearchSettingCommand { get; set; }

        IUserControlService _userControlService;
        public AdmissionCampaignViewModel(IUserControlService userControlService, MainTabControl<MainTabItem> data)
        {
            _userControlService = userControlService;
            this.data = data;
            Enrollees = new ObservableCollection<AddChangeEnrolleeViewModel>();
            Enrollees.CollectionChanged += (sender, e) =>
            {
                if(e.OldItems != null) foreach(AddChangeEnrolleeViewModel item in e.OldItems) item.OnDelete -= enrollee => Enrollees.Remove(enrollee);
                if(e.NewItems != null) foreach(AddChangeEnrolleeViewModel item in e.NewItems) item.OnDelete += enrollee => Enrollees.Remove(enrollee);
            };

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