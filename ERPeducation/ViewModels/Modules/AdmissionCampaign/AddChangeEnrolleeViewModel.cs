using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Windows.WindowDocuments;
using ERPeducation.Common.Windows.WindowEducation;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Windows.Controls;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class AddChangeEnrolleeViewModel : ReactiveObject
    {
        #region Личная Информация
        public string SurName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }

        [Reactive] public string SelectedGender { get; set; }
        [Reactive] public bool Popup { get; set; }
        [Reactive] public DateTime DateOfBirth { get; set; }

        [Reactive] public string Citizenship { get; set; }
        [Reactive] public bool IsEnabled { get; set; } = true;
        [Reactive] public DateTime DoCitizenship { get; set; }
        public ObservableCollection<PersonalDocumentBase> Documents { get; set; }

        PersonalDocumentBase selectedDocument;
        public PersonalDocumentBase SelectedDocument
        {
            get => selectedDocument;
            set
            {
                selectedDocument = value;
                _dialogDocument.GetUserControlDocument(UserControlDocument, SelectedDocument);
            }
        }

        public UserControl UserControlDocument { get; set; }

        #endregion
        #region Контактная Информация
        public string ResidenceAddress { get; set; }
        public string RegistrationAddress { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Mail { get; set; }
        #endregion
        #region Образование
        public ObservableCollection<EducationDocumentBase> Educations { get; set; }

        EducationDocumentBase selectedEducation;
        public EducationDocumentBase SelectedEducation
        {
            get => selectedEducation;
            set
            {
                selectedEducation = value;
                _dialogEducation.GetUserControlEducation(UserControlEducation, SelectedEducation);
            }
        }

        public UserControl UserControlEducation { get; set; }
        #endregion
        #region Поступление
        [Reactive] public ObservableCollection<string> LevelOfTraining { get; set; }
        [Reactive] public ObservableCollection<string> DirectionOfTraining { get; set; }
        [Reactive] public ObservableCollection<string> PreparationForm { get; set; }

        string seletedLvl;
        public string SeletedLvl
        {
            get => seletedLvl;
            set
            {
                this.RaiseAndSetIfChanged(ref seletedLvl, value);
                DirectionOfTraining = StaticData.GetDirectionEducation(SeletedLvl);
            }
        }

        string seletedDirection;
        public string SeletedDirection
        {
            get => seletedDirection;
            set
            {
                this.RaiseAndSetIfChanged(ref seletedDirection, value);
                PreparationForm = StaticData.GetFormEducation(SeletedDirection);
            }
        }

        [Reactive] public string SeletedForms { get; set; }
        #endregion





        #region Документы на печать
        #endregion
        #region Результаты испытаний
        #endregion



        #region Команды Личная Информация
        public ReactiveCommand<Unit,Unit> OpenPopupCommand { get; set; }
        public ReactiveCommand<Unit,Unit> OpenValueCommand { get; set; }
        public ReactiveCommand<Unit,Unit> DelValueCommand { get; set; }
        public ReactiveCommand<string,Unit> AddDocumentCommand { get; set; }
        #endregion
        #region Команды Образование
        public ReactiveCommand<string,Unit> AddEducationCommand { get; set; }
        #endregion
        #region Команды Поступление
        #endregion
        #region Команды Документы на печать
        #endregion
        #region Команды Результаты испытаний
        #endregion

        IDialogDocument _dialogDocument;
        IDialogEducation _dialogEducation;
        IJSONService _jsonService;
        public AddChangeEnrolleeViewModel(IDialogDocument dialogDocument, IDialogEducation dialogEducation, 
            IJSONService jsonService, ObservableCollection<EnrolleeViewModel> enrollees)
        {
            _dialogDocument = dialogDocument;
            _dialogEducation = dialogEducation;
            _jsonService = jsonService;

            #region Персональная информация
            Documents = new ObservableCollection<PersonalDocumentBase>();
            Documents.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (PersonalDocumentBase item in e.OldItems) item.OnDelete -= document => Documents.Remove(document);
                if (e.NewItems != null) foreach (PersonalDocumentBase item in e.NewItems) item.OnDelete += document => Documents.Remove(document);
            };
            UserControlDocument = new UserControl();
            InitializingCommandsPersonalInfo();
            #endregion
            #region Образование
            Educations = new ObservableCollection<EducationDocumentBase>();
            Educations.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (EducationDocumentBase item in e.OldItems) item.OnDelete -= education => Educations.Remove(education);
                if (e.NewItems != null) foreach (EducationDocumentBase item in e.NewItems) item.OnDelete += education => Educations.Remove(education);
            };
            UserControlEducation = new UserControl();
            AddEducationCommand = ReactiveCommand.Create<string>(parameter =>
            {
                if (parameter == "9th grade")
                {
                    _dialogEducation.GetBasicGeneral(Educations);
                    return;
                }
                if (parameter == "11th grade")
                {
                    _dialogEducation.GetBasicAverage(Educations);
                    return;
                }
                if (parameter == "SPO")
                {
                    _dialogEducation.GetSpo(Educations);
                    return;
                }
                if (parameter == "Undergraduate")
                {
                    _dialogEducation.GetUndergraduate(Educations);
                    return;
                }
                if (parameter == "Master")
                {
                    _dialogEducation.GetMaster(Educations);
                    return;
                }
                if (parameter == "Specialty")
                {
                    _dialogEducation.GetSpecialty(Educations);
                    return;
                }
            });
            #endregion

            #region Поступление
            LevelOfTraining = StaticData.GetLvlEducation();
            DirectionOfTraining = new ObservableCollection<string>();
            PreparationForm = new ObservableCollection<string>();
            #endregion
        }

        void InitializingCommandsPersonalInfo()
        {
            OpenPopupCommand = ReactiveCommand.Create(() =>
            {
                if (!Popup) Popup = true;
                else Popup = false;
            });
            OpenValueCommand = ReactiveCommand.Create(() =>
            {
                IsEnabled = true;
            });
            DelValueCommand = ReactiveCommand.Create(() =>
            {
                Citizenship = string.Empty;
                DoCitizenship = DateTime.MinValue;
                IsEnabled = false;
            });
            AddDocumentCommand = ReactiveCommand.Create<string>(parameter =>
            {
                if(parameter == "Passport") 
                {
                    _dialogDocument.GetPassport(Documents);
                    return;
                }
                if(parameter == "Snils")
                {
                    _dialogDocument.GetSnils(Documents);
                    return;
                }
                if(parameter == "Inn")
                {
                    _dialogDocument.GetInn(Documents);
                    return;
                }
                if(parameter == "ForeignPassport")
                {
                    _dialogDocument.GetForeignPassport(Documents);
                    return;
                }
            });
        }
    }
}