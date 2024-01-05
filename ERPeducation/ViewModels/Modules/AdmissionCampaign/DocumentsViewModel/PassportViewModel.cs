using ERPeducation.Command;
using ERPeducation.Interface;
using System;
using System.Windows;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class PassportViewModel : INPC
    {
        #region Свойства
        //Свойства данных паспорта
        public string IssuedBy { get; set; }
        public DateTime DateOfIssue { get; set; }
        public int DepartmentCode { get; set; }
        public int SeriesNumber { get; set; }

        //Свойства личных данных
        public string SurName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string[] Gender { get; set; } = { "Муж", "Жен" };
        string valueComboBox = string.Empty;
        public string ValueComboBox
        {
            get => valueComboBox;
            set
            {
                valueComboBox = value;
                OnPropertyChanged(nameof(ValueComboBox));
            }
        }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }

        //Свойства места жительства
        public string Location { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int Frame { get; set; }
        public int ApartmentNumber { get; set; }
        #endregion
        #region Команды
        public ICommand AddPassportCommand { get; set; }
        #endregion

        public PassportViewModel(EnrollePersonalInformationViewModel Main) 
        {
            AddPassportCommand = new RelayCommand(() => 
            {
                MessageBox.Show($"Выдан кем: {IssuedBy}\n" +
                    $"Дата выдачи: {DateOfIssue}\n" +
                    $"Код подразделения: {DepartmentCode}\n" +
                    $"Серия и номер: {SeriesNumber}\n\n" +
                    $"Фамилия: {SurName}\n" +
                    $"Имя: {Name}\n" +
                    $"Отчество: {MiddleName}\n" +
                    $"Дата рождения: {DateOfBirth}\n" +
                    $"Пол: {ValueComboBox}\n" +
                    $"Место рождения: {PlaceOfBirth}\n\n" +
                    $"Орган выдавший паспорт: {Location}\n" +
                    $"Город: {City}\n" +
                    $"Ул.: {Street}\n" +
                    $"Номер дом: {HouseNumber}\n" +
                    $"Корпус: {Frame}\n" +
                    $"Номер квартиры: {ApartmentNumber}", "Паспорт");
            });
        }
    }
}
