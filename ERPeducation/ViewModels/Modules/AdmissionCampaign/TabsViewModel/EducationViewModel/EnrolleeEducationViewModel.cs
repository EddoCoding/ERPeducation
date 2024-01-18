using ERPeducation.Command;
using ERPeducation.Common.Interface.DialogEducation;
using ERPeducation.Common.Interface.DialogPersonal;
using ERPeducation.Models.AdmissionCampaign.EducationDocuments;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel
{
    public class EnrolleeEducationViewModel : ReactiveObject
    {
        #region Свойства контролов
        public ObservableCollection<TypeEducationBaseModel> Education { get; set; }

        TypeEducationBaseModel selectedEducation;
        public TypeEducationBaseModel SelectedEducation
        {
            get => selectedEducation;
            set
            {
                selectedEducation = value;
                UserControl = _dialogServiceEducation.GetUserControl(selectedEducation);
            }
        }

        [Reactive] public UserControl UserControl { get; set; }
        #endregion
        #region Команды
        public ICommand AddEducatinCommand { get; set; }
        public ICommand DeleteEducatinCommand { get; set; }
        public ICommand EditEducatinCommand { get; set; }
        #endregion

        IDialogService _dialogService;
        IDialogServiceEducation _dialogServiceEducation;

        public EnrolleeEducationViewModel(IDialogService dialogService, IDialogServiceEducation dialogServiceEducation)
        {
            UserControl = new UserControl();

            _dialogService = dialogService;
            _dialogServiceEducation = dialogServiceEducation;

            Education = new ObservableCollection<TypeEducationBaseModel>();

            AddEducatinCommand = new RelayCommand(OpenWindowEducationDocument);
            DeleteEducatinCommand = new RelayCommand(DeleteEducationDocument);
            EditEducatinCommand = new RelayCommand(EditEducationDocument);
        }

        void OpenWindowEducationDocument() => _dialogService.OpenWindow(this);
        void DeleteEducationDocument() => Education.Remove(SelectedEducation);
        void EditEducationDocument() => _dialogService.ShowUserControlEducationDocumentsForEdit(SelectedEducation, this);
    }
}