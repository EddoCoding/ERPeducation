using ERPeducation.Common;
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
        public ObservableCollection<AddEnrolleeViewModel> Enrollees { get; set; }
        [Reactive] public Enrollee SelectedEnrollee { get; set; }
        #endregion
        #region Команды
        public ReactiveCommand<Unit, Unit> AddEnrolleeCommand { get; set; }
        public ReactiveCommand<Unit, Unit> WithdrawStatementCommand { get; set; }
        public ReactiveCommand<Unit, Unit> FilterCommand { get; set; }
        #endregion

        public AdmissionCampaignViewModel(IUserControlService userControlService, BaseDataForModules<TabItemMainWindowViewModel> data)
        {
            Enrollees = new ObservableCollection<AddEnrolleeViewModel>();

            AddEnrolleeCommand = ReactiveCommand.Create(() =>
            {
                data.TabItem.Add(new TabItemMainWindowViewModel("Абитуриент", userControlService.GetUserControlEnrollee(Enrollees)));
            });
            WithdrawStatementCommand = ReactiveCommand.Create(() => { MessageBox.Show("Метод не реализован", "Сообщение", MessageBoxButton.OK); });
            FilterCommand = ReactiveCommand.Create(() => { MessageBox.Show("Метод не реализован", "Сообщение", MessageBoxButton.OK); });
        }
    }
}