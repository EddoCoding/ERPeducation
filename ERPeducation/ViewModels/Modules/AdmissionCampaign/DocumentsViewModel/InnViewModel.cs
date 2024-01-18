using ERPeducation.Command;
using ERPeducation.Common.Interface.DialogModel;
using ERPeducation.Interface;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.PersonalInformation;
using System;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class InnViewModel : INPC
    {
        //Свойства данных ИНН
        #region Свойства
        DateTime dateOfAssignment;
        public DateTime DateOfAssignment
        {
            get => dateOfAssignment;
            set
            {
                dateOfAssignment = value;
                OnPropertyChanged(nameof(DateOfAssignment));
            }
        }

        private bool openPopupDateOfAssignment;
        public bool OpenPopupDateOfAssignment
        {
            get => openPopupDateOfAssignment;
            set
            {
                openPopupDateOfAssignment = value;
                OnPropertyChanged(nameof(OpenPopupDateOfAssignment));
            }
        }

        public long NumberINN { get; set; }
        public string Organization { get; set; }
        public string SeriesNumber { get; set; }

        public string TitleButton { get; set; } = "Добавить документ";
        #endregion
        #region Команды
        public ICommand OpenPopupForDateOfAssignment { get; set; }
        public ICommand AddInnCommand { get; set; }
        #endregion

        IConnectionModelService _connectModel;

        public InnViewModel(EnrollePersonalInformationViewModel Main, IConnectionModelService connectModel, Action closeWindow)
        {
            _connectModel = connectModel;

            OpenPopupForDateOfAssignment = new RelayCommand(() => 
            {
                if (OpenPopupDateOfAssignment == false) OpenPopupDateOfAssignment = true;
                else OpenPopupDateOfAssignment = false;
            });

            AddInnCommand = new RelayCommand(() =>
            {
                Main.Documents.Add(_connectModel.GetModel(this));
                closeWindow();
            });
        }
    }
}
