using ERPeducation.Command;
using ERPeducation.Common.Interface;
using ERPeducation.Views.AdmissionCampaign.TabsView.TabEducation.DocumentsView;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel
{
    public class EducationViewModel : ReactiveObject
    {
        #region Свойства контролов
        EnrolleeEducationViewModel ViewModel;
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
                    UserControl = _dialogService.GetUserControlForTypeEducationDocument(SelectedEducation, ViewModel);
                }
                if (SelectedEducation == "Среднее общее")
                {
                    ValueComboBox = SelectedEducation;
                    UserControl = _dialogService.GetUserControlForTypeEducationDocument(SelectedEducation, ViewModel);
                }
                if (SelectedEducation == "Среднее профессиональное")
                {
                    ValueComboBox = SelectedEducation;
                    UserControl = _dialogService.GetUserControlForTypeEducationDocument(SelectedEducation, ViewModel);
                }
                if (SelectedEducation == "Бакалавриат")
                {

                    ValueComboBox = SelectedEducation;
                    UserControl = _dialogService.GetUserControlForTypeEducationDocument(SelectedEducation, ViewModel);
                }
                if (SelectedEducation == "Магистратура")
                {
                    ValueComboBox = SelectedEducation;
                    UserControl = _dialogService.GetUserControlForTypeEducationDocument(SelectedEducation, ViewModel);
                }
                if (SelectedEducation == "Аспирантура")
                {
                    ValueComboBox = SelectedEducation;
                    UserControl = _dialogService.GetUserControlForTypeEducationDocument(SelectedEducation, ViewModel);
                }
            }
        }

        [Reactive] public string ValueComboBox { get; set; }
        [Reactive] public UserControl UserControl { get; set; }

        #endregion
        #region Команды
        public ICommand CloseWindow {  get; set; }
        #endregion

        IDialogService _dialogService;

        public EducationViewModel(IDialogService dialogService, EnrolleeEducationViewModel viewModel, Action closeWindow) 
        {
            _dialogService = dialogService;

            ViewModel = viewModel;

            CloseWindow = new RelayCommand(closeWindow);
        }
    }
}
