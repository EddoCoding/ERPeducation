using ERPeducation.Command;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Windows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel
{
    public class EnrolleeEducationViewModel
    {
        #region Свойства
        public ObservableCollection<string> Education { get; set; }
        public ObservableCollection<string> AdditionalEducation { get; set; } 
        #endregion
        #region Команды
        public ICommand AddEducatinCommand { get; set; }
        public ICommand DeleteEducatinCommand { get; set; }
        public ICommand EditEducatinCommand { get; set; }
        public ICommand AddAdditionalEducatinCommand { get; set; }
        public ICommand DeleteAdditionalEducatinCommand { get; set; }
        public ICommand EditAdditionalEducatinCommand { get; set; }
        #endregion

        IDialogService _dialogService;

        public EnrolleeEducationViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            Education = new ObservableCollection<string>();
            AdditionalEducation = new ObservableCollection<string>();

            AddEducatinCommand = new RelayCommand(() => { _dialogService.OpenWindow(this); });
            DeleteEducatinCommand = new RelayCommand(() => { MessageBox.Show("Проверка2"); });
            EditEducatinCommand = new RelayCommand(() => { MessageBox.Show("Проверка3"); });

            AddAdditionalEducatinCommand = new RelayCommand(() => { AdditionalEducation.Add("Строка2"); });
            DeleteAdditionalEducatinCommand = new RelayCommand(() => { MessageBox.Show("Проверка5"); });
            EditAdditionalEducatinCommand = new RelayCommand(() => { MessageBox.Show("Проверка6"); });
        }
    }
}
