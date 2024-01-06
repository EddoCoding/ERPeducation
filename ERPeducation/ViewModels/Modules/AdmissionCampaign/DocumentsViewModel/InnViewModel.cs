using ERPeducation.Command;
using ERPeducation.Interface;
using System;
using System.Windows;
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
        #endregion
        #region Команды
        public ICommand OpenPopupForDateOfAssignment { get; set; }
        public ICommand AddInnCommand { get; set; }
        #endregion

        public InnViewModel(EnrollePersonalInformationViewModel Main)
        {
            OpenPopupForDateOfAssignment = new RelayCommand(() => 
            {
                if (OpenPopupDateOfAssignment == false) OpenPopupDateOfAssignment = true;
                else OpenPopupDateOfAssignment = false;
            });

            AddInnCommand = new RelayCommand(() =>
            {
                MessageBox.Show($"Дата присвоения: {DateOfAssignment}\n" +
                    $"Номер ИНН: {NumberINN}\n" +
                    $"Орган выдавший: {Organization}\n" +
                    $"Серия и номер: {SeriesNumber}");
            });
        }
    }
}
