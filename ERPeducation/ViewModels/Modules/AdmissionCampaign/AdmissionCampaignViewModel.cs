using ERPeducation.Command;
using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class AdmissionCampaignViewModel
    {
        #region Свойства
        MainWindowViewModel mainWindowViewModel {  get; set; }
        public ObservableCollection<Enrollee> Enrollees { get; set; }
        Enrollee selectedEnrollee;
        public Enrollee SelectedEnrollee
        {
            get => selectedEnrollee;
            set => selectedEnrollee = value;
        }
        #endregion
        #region Команды
        public ICommand AddEnrolleeCommand { get; set; }
        public ICommand WithdrawStatementCommand { get; set; }
        public ICommand FilterCommand { get; set; }
        #endregion

        public AdmissionCampaignViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            AddEnrolleeCommand = new RelayCommand(() => mainWindowViewModel.Data.TabItem.Add(new TabItemMainWindowViewModel("Абитуриент", new ModuleEnrollee(new EnrolleeViewModel()))));
            WithdrawStatementCommand = new RelayCommand(() => MessageBox.Show("Метод не реализован", "Сообщение", MessageBoxButton.OK));
            FilterCommand = new RelayCommand(() => MessageBox.Show("Метод не реализован", "Сообщение", MessageBoxButton.OK));

            Enrollees = new ObservableCollection<Enrollee>()
            {
                new Enrollee("Викторова1", "Виктория1", "Викторовна1"),
                new Enrollee("Викторова2", "Виктория2", "Викторовна2"),
                new Enrollee("Викторова3", "Виктория3", "Викторовна3"),
                new Enrollee("Викторова4", "Виктория4", "Викторовна4")
            };
        }
    }
}