using ERPeducation.Command;
using ERPeducation.Interface;
using ERPeducation.Models.AdmissionCampaign.Documents;
using System;
using System.Windows;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class ForeignPassportViewModel : INPC
    {
        //Данные иностранного паспорта
        #region Свойства
        public string Abbreviation { get; set; }
        public int Number { get; set; }
        public string IssuedBy { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime Validity { get; set; }

        //Личный данные
        public string SurName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
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
        public string PlaceOfBirth { get; set; }
        public string Citizenship { get; set; }
        #endregion
        #region Команды
        public ICommand AddForeignPassportCommand { get; set; }
        #endregion

        public ForeignPassportViewModel(EnrollePersonalInformationViewModel Main)
        {
            AddForeignPassportCommand = new RelayCommand(() =>
            {
                MessageBox.Show($"Аббревиатура: {Abbreviation} Номер: {Number}\n" +
                    $"Выдан кем: {IssuedBy}\n" +
                    $"Дата выдачи: {DateOfIssue}\n" +
                    $"Действует до: {Validity}\n\n" +
                    $"Фамилия {SurName}\n" +
                    $"Имя: {Name}\n" +
                    $"Отчество: {MiddleName}\n" +
                    $"Дата рождения: {DateOfBirth}\n" +
                    $"Пол: {ValueComboBox}\n" +
                    $"Место рождения: {PlaceOfBirth}\n" +
                    $"Гражданство: {Citizenship}");
            });
        }
    }
}
