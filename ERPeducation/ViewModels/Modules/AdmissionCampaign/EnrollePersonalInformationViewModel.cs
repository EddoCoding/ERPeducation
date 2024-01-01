using ERPeducation.Command;
using ERPeducation.Interface;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class EnrollePersonalInformationViewModel : INPC
    {
        #region Визуальные свойства
        //public Brush BackGround { get; set; } = new SolidColorBrush(Color.FromRgb(0,0,0));
        //public float Opacity { get; set; } = 1.0f;
        #endregion


        #region Свойства
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
                IsValidFrom = dateOfBirth;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        } //Свойство для хранения даты дня рождения

        private bool openPopup;
        public bool OpenPopup
        {
            get => openPopup;
            set
            {
                openPopup = value;
                OnPropertyChanged(nameof(OpenPopup));
            }
        } //Свойство для открывания/закрывания календаря

        string citizenship;
        public string Citizenship
        {
            get => citizenship;
            set
            {
                citizenship = value;
                OnPropertyChanged(nameof(Citizenship));
            }
        }

        DateTime isValidFrom;
        public DateTime IsValidFrom
        {
            get => isValidFrom;
            set
            {
                isValidFrom = value;
                OnPropertyChanged(nameof(IsValidFrom));
            }
        }






        private bool radioButtonCitizenship = true;
        public bool RadioButtonСitizenship
        {
            get => radioButtonCitizenship;
            set
            {
                if (value != radioButtonCitizenship)
                {
                    radioButtonCitizenship = value;
                    if (radioButtonCitizenship)
                    {
                        radioButtonWithoutСitizenship = false;
                        OnPropertyChanged(nameof(RadioButtonWithoutСitizenship));
                    }
                    OnPropertyChanged(nameof(RadioButtonСitizenship));
                }
            }
        }

        private bool radioButtonWithoutСitizenship;
        public bool RadioButtonWithoutСitizenship
        {
            get => radioButtonWithoutСitizenship;
            set
            {
                if (value != radioButtonWithoutСitizenship)
                {
                    radioButtonWithoutСitizenship = value;
                    if (radioButtonWithoutСitizenship)
                    {
                        radioButtonCitizenship = false;
                        OnPropertyChanged(nameof(RadioButtonСitizenship));
                    }
                    OnPropertyChanged(nameof(RadioButtonWithoutСitizenship));
                }
            }
        }
        #endregion





        #region Команды
        public ICommand OpenPopupCommand { get; set; }
        public ICommand ForCheck { get; set; }
        #endregion

        public EnrollePersonalInformationViewModel()
        {
            OpenPopupCommand = new RelayCommand(() =>
            {
                if (OpenPopup == false) OpenPopup = true;
                else OpenPopup = false;
            });

            ForCheck = new RelayCommand(() => { MessageBox.Show($"Фамилия: {SurName} Имя: {Name} Отчество: {MiddleName}\n" +
                                                                $"Пол: {ValueComboBox}\n" +
                                                                $"Дата рождения: {DateOfBirth.ToShortDateString()}\n" +
                                                                $"Гражданство: {Citizenship} Действует с: {IsValidFrom.ToShortDateString()}"); });
        }
    }
}