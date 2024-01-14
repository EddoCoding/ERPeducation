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
                    ValueComboBox = "Основное общее";
                    TypeEducationDocument = "Аттестат об Основном общем образовании";
                    UserControl = new Certificate();
                }
                if (SelectedEducation == "Среднее общее")
                {
                    ValueComboBox = "Среднее общее";
                    TypeEducationDocument = "Аттестат о Среднем общем образовании";
                    UserControl = new Certificate();
                }
                if (SelectedEducation == "Среднее профессиональное")
                {
                    ValueComboBox = "Среднее профессиональное";
                    TypeEducationDocument = "Диплом о Среднем профессиональном образовании";
                    UserControl = new Diploma();
                }
                if (SelectedEducation == "Бакалавриат")
                {

                    ValueComboBox = "Бакалавриат";
                    TypeEducationDocument = "Диплом Бакалавра";
                    UserControl = new Diploma();
                }
                if (SelectedEducation == "Магистратура")
                {
                    ValueComboBox = "Магистратура";
                    TypeEducationDocument = "Диплом Магистра";
                    UserControl = new Diploma();
                }
                if (SelectedEducation == "Аспирантура")
                {
                    ValueComboBox = "Аспирантура";
                    TypeEducationDocument = "Диплом об окончании Аспирантуры";
                    UserControl = new Diploma();
                }
            }
        }
        [Reactive] public string ValueComboBox { get; set; }

        [Reactive] public string TypeEducationDocument { get; set; }
        [Reactive] public UserControl UserControl { get; set; }

        #endregion
        #region Команды
        public ICommand CloseWindow {  get; set; }
        #endregion

        IDialogService _dialogService;

        public EducationViewModel(IDialogService dialogService, EnrolleeEducationViewModel viewModel, Action closeWindow) 
        {
            _dialogService = dialogService;

            CloseWindow = new RelayCommand(closeWindow);
        }
    }
}
