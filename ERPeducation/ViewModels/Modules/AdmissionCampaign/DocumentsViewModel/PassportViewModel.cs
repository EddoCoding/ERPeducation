using ERPeducation.Command;
using ERPeducation.Common.Interface;
using ERPeducation.Interface;
using System;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class PassportViewModel : INPC
    {
        #region Свойства
        //Свойства данных паспорта
        public string IssuedBy { get; set; }
        DateTime dateOfIssue;
        public DateTime DateOfIssue
        {
            get => dateOfIssue;
            set
            {
                dateOfIssue = value;
                OnPropertyChanged(nameof(DateOfIssue));
            }
        }
        public string DepartmentCode { get; set; }
        public string SeriesNumber { get; set; }

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
        DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }
        public string PlaceOfBirth { get; set; }

        //Свойства места жительства
        public string Location { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Frame { get; set; }
        public string ApartmentNumber { get; set; }

        private bool openPopupDateOfIssue;
        public bool OpenPopupDateOfIssue
        {
            get => openPopupDateOfIssue;
            set
            {
                openPopupDateOfIssue = value;
                OnPropertyChanged(nameof(OpenPopupDateOfIssue));
            }
        }

        private bool openPopupDateOfBirth;
        public bool OpenPopupDateOfBirth
        {
            get => openPopupDateOfBirth;
            set
            {
                openPopupDateOfBirth = value;
                OnPropertyChanged(nameof(OpenPopupDateOfBirth));
            }
        }
        #endregion
        #region Команды
        public ICommand OpenPopupForDateOfIssueCommand { get; set; }
        public ICommand OpenPopupForDateOfBirthCommand { get; set; }
        public ICommand AddPassportCommand { get; set; }
        #endregion

        IConnectionModelService _connectModel;

        public PassportViewModel(EnrollePersonalInformationViewModel Main, IConnectionModelService connectModel) 
        {
            _connectModel = connectModel;

            OpenPopupForDateOfIssueCommand = new RelayCommand(() =>
            {
                if (OpenPopupDateOfIssue == false) OpenPopupDateOfIssue = true;
                else OpenPopupDateOfIssue = false;
            });
            OpenPopupForDateOfBirthCommand = new RelayCommand(() =>
            {
                if (OpenPopupDateOfBirth == false) OpenPopupDateOfBirth = true;
                else OpenPopupDateOfBirth = false;
            });

            AddPassportCommand = new RelayCommand(() => 
            {
                Main.Documents.Add(_connectModel.GetModelDocument(this));
            });
        }
    }
}