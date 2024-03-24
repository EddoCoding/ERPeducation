using ERPeducation.Common.BD;
using ERPeducation.Common.Command;
using ERPeducation.Common.Windows.WindowDirection;
using ERPeducation.Common.Windows.WindowDocuments;
using ERPeducation.Common.Windows.WindowEducation;
using ERPeducation.Common.Windows.WindowTest;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
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
        public ObservableCollection<DirectionViewModel> Directions { get; set; }

        DirectionViewModel selectedDirection;
        public DirectionViewModel SelectedDirection
        {
            get => selectedDirection;
            set
            {
                selectedDirection = value;
                _dialogDirection.GetUserControlDirection(UserControlDirection, SelectedDirection);
            }
        }

        [Reactive] public UserControl UserControlDirection { get; set; }
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
        public ReactiveCommand<Unit,Unit> AddDirection { get; set; }
        #endregion
        #region Команды Документы на печать
        #endregion
        #region Команды Результаты испытаний
        #endregion

        IDialogDocument _dialogDocument;
        IDialogEducation _dialogEducation;
        IDialogDirection _dialogDirection;
        public AddChangeEnrolleeViewModel(IDialogDocument dialogDocument, IDialogEducation dialogEducation, 
            IDialogDirection dialogDirection, ObservableCollection<EnrolleeViewModel> enrollees)
        {
            _dialogDocument = dialogDocument;
            _dialogEducation = dialogEducation;
            _dialogDirection = dialogDirection;

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
                if (e.OldItems != null) foreach(EducationDocumentBase item in e.OldItems) item.OnDelete -= education => Educations.Remove(education);
                if (e.NewItems != null) foreach(EducationDocumentBase item in e.NewItems) item.OnDelete += education => Educations.Remove(education);
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
            Directions = new ObservableCollection<DirectionViewModel>();
            Directions.CollectionChanged += (sender, e) =>
            { 
                if(e.OldItems != null) foreach(DirectionViewModel item in e.OldItems) item.OnDelete -= direction => Directions.Remove(item);
                if(e.NewItems != null) foreach(DirectionViewModel item in e.NewItems) item.OnDelete += direction => Directions.Remove(item);
            };
            UserControlDirection = new UserControl();
            AddDirection = ReactiveCommand.Create(() =>
            {
                dialogDirection.GetDirection(Directions);
            });
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