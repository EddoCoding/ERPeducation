using ERPeducation.Command;
using ERPeducation.Common.Interface;
using ERPeducation.Interface;
using ERPeducation.Views.AdmissionCampaign.TabsView.TabEducation.DocumentsView;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel
{
    public class EducationViewModel : INPC
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
                OnPropertyChanged(nameof(SelectedEducation));
                if (SelectedEducation == "Основное общее")
                {
                    UserControl = new Certificate();
                }
            }
        }

        UserControl userControl;
        public UserControl UserControl
        {
            get => userControl;
            set
            {
                userControl = value;
                OnPropertyChanged(nameof(UserControl));
            }
        }

        public string[] EducationDocuments { get; set; } = { "Аттестат об Основном общем образовании", "Аттестат о Среднем общем образовании",
                                                             "Диплом о Среднем профессиональном образовании", "Диплом Бакалавра",
                                                             "Диплом Магистра", "Диплом об окончании Аспирантуры"};

        string selectedEducationDocument;
        public string SelectedEducationDocument
        {
            get => selectedEducationDocument;
            set
            {
                selectedEducationDocument = value;
                OnPropertyChanged(nameof(SelectedEducationDocument));
            }
        }


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
