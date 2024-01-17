using ERPeducation.Command;
using ERPeducation.Common.Interface;
using ERPeducation.Models.AdmissionCampaign.EducationDocuments;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel
{
    public class EnrolleeEducationViewModel : ReactiveObject
    {
        #region Свойства контролов
        public ObservableCollection<TypeEducationBaseModel> Education { get; set; }
        public ObservableCollection<string> AdditionalEducation { get; set; }
        public TypeEducationBaseModel SelectedEducation { get; set; }
        public string SelectedEducation2 { get; set; } // для второй listview
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

            Education = new ObservableCollection<TypeEducationBaseModel>();
            AdditionalEducation = new ObservableCollection<string>();

            AddEducatinCommand = new RelayCommand(OpenWindowEducationDocument);
            DeleteEducatinCommand = new RelayCommand(DeleteEducationDocument);
            EditEducatinCommand = new RelayCommand(EditEducationDocument);

            AddAdditionalEducatinCommand = new RelayCommand(() => { AdditionalEducation.Add("Строка2"); });
            DeleteAdditionalEducatinCommand = new RelayCommand(() => { MessageBox.Show("Проверка5"); });
            EditAdditionalEducatinCommand = new RelayCommand(() => { MessageBox.Show("Проверка6"); });
        }

        void OpenWindowEducationDocument() => _dialogService.OpenWindow(this);
        void DeleteEducationDocument() => Education.Remove(SelectedEducation);
        void EditEducationDocument() => _dialogService.ShowUserControlEducationDocumentsForEdit(SelectedEducation, this);
    }
}