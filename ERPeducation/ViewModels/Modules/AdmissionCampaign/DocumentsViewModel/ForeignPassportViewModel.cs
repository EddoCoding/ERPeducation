using ERPeducation.Command;
using ERPeducation.Common.Interface;
using ERPeducation.Interface;
using System;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class ForeignPassportViewModel : INPC
    {
        //Данные иностранного паспорта
        #region Свойства
        public string Abbreviation { get; set; }
        public string Number { get; set; }
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

        DateTime validity;
        public DateTime Validity
        {
            get => validity;
            set
            {
                validity = value;
                OnPropertyChanged(nameof(Validity));
            }
        }

        private bool openPopupValidity;
        public bool OpenPopupValidity
        {
            get => openPopupValidity;
            set
            {
                openPopupValidity = value;
                OnPropertyChanged(nameof(OpenPopupValidity));
            }
        }

        //Личный данные
        public string SurName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }

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

        private bool openPopupForDateOfBirth;
        public bool OpenPopupForDateOfBirth
        {
            get => openPopupForDateOfBirth;
            set
            {
                openPopupForDateOfBirth = value;
                OnPropertyChanged(nameof(OpenPopupForDateOfBirth));
            }
        }

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

        public string TitleButton { get; set; } = "Добавить документ";
        #endregion
        #region Команды
        public ICommand OpenPopupForDateOfIssueCommand { get; set; }
        public ICommand OpenPopupForValidityCommand { get; set; }
        public ICommand OpenPopupForDateOfBirthCommand { get; set; }
        public ICommand AddForeignPassportCommand { get; set; }
        #endregion

        IConnectionModelService _connectModel;

        public ForeignPassportViewModel(EnrollePersonalInformationViewModel Main, IConnectionModelService connectModel, Action closeWindow)
        {
            _connectModel = connectModel;

            OpenPopupForDateOfIssueCommand = new RelayCommand(() =>
            {
                if (OpenPopupDateOfIssue == false) OpenPopupDateOfIssue = true;
                else OpenPopupDateOfIssue = false;
            });
            OpenPopupForDateOfBirthCommand = new RelayCommand(() =>
            {
                if (OpenPopupForDateOfBirth == false) OpenPopupForDateOfBirth = true;
                else OpenPopupForDateOfBirth = false;
            });
            OpenPopupForValidityCommand = new RelayCommand(() =>
            {
                if (OpenPopupValidity == false) OpenPopupValidity = true;
                else OpenPopupValidity = false;
            });

            AddForeignPassportCommand = new RelayCommand(() =>
            {
                Main.Documents.Add(_connectModel.GetModelDocument(this));
                closeWindow();
            });
        }
    }
}
