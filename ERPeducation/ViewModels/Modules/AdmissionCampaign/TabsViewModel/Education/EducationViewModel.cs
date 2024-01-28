using ERPeducation.Command;
using ERPeducation.Common.Interface;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Windows.Controls;
using System.Windows.Input;


namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel
{
    public class EducationViewModel : ReactiveObject
    {
        EnrolleeEducationViewModel ViewModel;

        #region Свойства контролов
        public string TitleButton { get; set; } = "Отменить изменение"; //Для окна изменения бразования
        public string TypeDocument { get; set; } //Тоже

        public string[] EducationLevels { get; set; } = { "Основное общее", "Среднее общее", "Среднее профессиональное",
                                                          "Бакалавриат", "Магистратура", "Аспирантура" };

        string selectedEducation;
        public string SelectedEducation
        {
            get => selectedEducation;
            set
            {
                selectedEducation = value;

                if (SelectedEducation == "Основное общее")
                {
                    ValueComboBox = SelectedEducation;
                    UserControl = _userControlService.GetUserControlForTypeEducationDocument(SelectedEducation, ViewModel, closeWindow);
                }
                if (SelectedEducation == "Среднее общее")
                {
                    ValueComboBox = SelectedEducation;
                    UserControl = _userControlService.GetUserControlForTypeEducationDocument(SelectedEducation, ViewModel, closeWindow);
                }
                if (SelectedEducation == "Среднее профессиональное")
                {
                    ValueComboBox = SelectedEducation;
                    UserControl = _userControlService.GetUserControlForTypeEducationDocument(SelectedEducation, ViewModel, closeWindow);
                }
                if (SelectedEducation == "Бакалавриат")
                {

                    ValueComboBox = SelectedEducation;
                    UserControl = _userControlService.GetUserControlForTypeEducationDocument(SelectedEducation, ViewModel, closeWindow);
                }
                if (SelectedEducation == "Магистратура")
                {
                    ValueComboBox = SelectedEducation;
                    UserControl = _userControlService.GetUserControlForTypeEducationDocument(SelectedEducation, ViewModel, closeWindow);
                }
                if (SelectedEducation == "Аспирантура")
                {
                    ValueComboBox = SelectedEducation;
                    UserControl = _userControlService.GetUserControlForTypeEducationDocument(SelectedEducation, ViewModel, closeWindow);
                }
            }
        }

        [Reactive] public string ValueComboBox { get; set; }
        [Reactive] public UserControl UserControl { get; set; }

        Action closeWindow;
        #endregion
        #region Команды
        public ICommand CloseWindow {  get; set; }
        #endregion

        IUserControlService _userControlService;

        public EducationViewModel(IUserControlService userControlService, EnrolleeEducationViewModel viewModel, Action closeWindow) 
        {
            _userControlService = userControlService;

            ViewModel = viewModel;

            this.closeWindow = closeWindow;

            CloseWindow = new RelayCommand(this.closeWindow);
        }
    }
}
