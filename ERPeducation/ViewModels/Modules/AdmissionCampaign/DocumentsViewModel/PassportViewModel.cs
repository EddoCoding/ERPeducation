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
        string issuedBy;
        public string IssuedBy
        {
            get => issuedBy;
            set
            {
                issuedBy = value;
                OnPropertyChanged(nameof(IssuedBy));
            }
        }

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

        string departmentCode;
        public string DepartmentCode
        {
            get => departmentCode;
            set
            {
                departmentCode = value;
                OnPropertyChanged(nameof(DepartmentCode));
            }
        }

        string seriesNumber;
        public string SeriesNumber
        {
            get => seriesNumber;
            set
            {
                seriesNumber = value;
                OnPropertyChanged(nameof(SeriesNumber));
            }
        }

        //Свойства личных данных
        string surName;
        public string SurName
        {
            get => surName;
            set
            {
                surName = value;
                OnPropertyChanged(nameof(SurName));
            }
        }

        string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        string middleName;
        public string MiddleName
        {
            get => middleName;
            set
            {
                middleName = value;
                OnPropertyChanged(nameof(MiddleName));
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

        string placeOfBirth;
        public string PlaceOfBirth
        {
            get => placeOfBirth;
            set
            {
                placeOfBirth = value;
                OnPropertyChanged(nameof(PlaceOfBirth));
            }
        }

        //Свойства места жительства
        string location;
        public string Location
        {
            get => location;
            set
            {
                location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        string city;
        public string City
        {
            get => city;
            set
            {
                city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        string street;
        public string Street
        {
            get => street;
            set
            {
                street = value;
                OnPropertyChanged(nameof(Street));
            }
        }

        string houseNumber;
        public string HouseNumber
        {
            get => houseNumber;
            set
            {
                houseNumber = value;
                OnPropertyChanged(nameof(HouseNumber));
            }
        }

        string frame;
        public string Frame
        {
            get => frame;
            set
            {
                frame = value;
                OnPropertyChanged(nameof(Frame));
            }
        }

        string apartmentNumber;
        public string ApartmentNumber
        {
            get => apartmentNumber;
            set
            {
                apartmentNumber = value;
                OnPropertyChanged(nameof(ApartmentNumber));
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

        public string TitleButton { get; set; } = "Добавить документ";
        #endregion
        #region Команды
        public ICommand OpenPopupForDateOfIssueCommand { get; set; }
        public ICommand OpenPopupForDateOfBirthCommand { get; set; }
        public ICommand AddPassportCommand { get; set; }
        #endregion

        IConnectionModelService _connectModel;

        public PassportViewModel(EnrollePersonalInformationViewModel Main, IConnectionModelService connectModel, Action closeWindow) 
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
                closeWindow();
            });
        }
    }
}