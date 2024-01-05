using ERPeducation.Command;
using System;
using System.Windows;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class InnViewModel
    {
        //Свойства данных ИНН
        #region Свойства
        public DateTime DateOfAssignment { get; set; }
        public long NumberINN { get; set; }
        public string Organization { get; set; }
        public int SeriesNumber { get; set; }
        #endregion
        #region Команды
        public ICommand AddInnCommand { get; set; }
        #endregion

        public InnViewModel(EnrollePersonalInformationViewModel Main)
        {
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
