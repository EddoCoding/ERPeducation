using ERPeducation.Common.Interface.DialogPersonal;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;
using System.Windows.Controls;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.FieldOfStudy
{
    public class FieldOfStudyViewModel : ReactiveObject
    {
        #region Свойства контролов
        public ObservableCollection<object> FieldsOfStudy { get; set; }

        public object SelectedField { get; set; }

        public UserControl UserControl { get; set; }
        #endregion
        #region Команды
        public ReactiveCommand<Unit, Unit> Add { get; set; }
        public ReactiveCommand<Unit, Unit> Del { get; set; }
        public ReactiveCommand<Unit, Unit> Edit { get; set; }
        #endregion

        IDialogService _dialogService;
        public FieldOfStudyViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            FieldsOfStudy = new ObservableCollection<object>();
            UserControl = new UserControl();

            Add = ReactiveCommand.Create(OpenWindowAddFiled);
            Del = ReactiveCommand.Create(DeleteFiled);
            Edit = ReactiveCommand.Create(OpenWindowEditField);
        }

        void OpenWindowAddFiled() => _dialogService.OpenWindow(this);
        void DeleteFiled() => FieldsOfStudy.Remove(SelectedField);
        void OpenWindowEditField() => MessageBox.Show("Метод не реализован");
    }
}
