using ERPeducation.Common.Interface;
using ERPeducation.Models.AdmissionCampaign;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class AdmissionCampaignViewModel : ReactiveObject
    {
        #region Свойства
        MainWindowViewModel mainWindowViewModel {  get; set; }
        public ObservableCollection<Enrollee> Enrollees { get; set; }
        [Reactive] public Enrollee SelectedEnrollee {  get; set; }
        #endregion
        #region Команды
        public ReactiveCommand<Unit, Unit> AddEnrolleeCommand { get; set; }
        public ReactiveCommand<Unit, Unit> WithdrawStatementCommand { get; set; }
        public ReactiveCommand<Unit, Unit> FilterCommand { get; set; }
        #endregion

        IUserControlService _userControlService;

        public AdmissionCampaignViewModel(IUserControlService userControlService, MainWindowViewModel mainWindowViewModel)
        {
            _userControlService = userControlService;

            this.mainWindowViewModel = mainWindowViewModel;

            AddEnrolleeCommand = ReactiveCommand.Create(AddEnrollee);
            WithdrawStatementCommand = ReactiveCommand.Create(() => { MessageBox.Show("Метод не реализован", "Сообщение", MessageBoxButton.OK); });
            FilterCommand = ReactiveCommand.Create(() => { MessageBox.Show("Метод не реализован", "Сообщение", MessageBoxButton.OK); });

            Enrollees = new ObservableCollection<Enrollee>()
            {
                new Enrollee("Викторова1", "Виктория1", "Викторовна1"),
                new Enrollee("Викторова2", "Виктория2", "Викторовна2"),
                new Enrollee("Викторова3", "Виктория3", "Викторовна3"),
                new Enrollee("Викторова4", "Виктория4", "Викторовна4")
            };
        }

        void AddEnrollee() =>
            mainWindowViewModel.Data.TabItem.Add(new TabItemMainWindowViewModel("Абитуриент",
                _userControlService.GetUserControlForAdmissionCampaign("Абитуриент")));
        
    }
}