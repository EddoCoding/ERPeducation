using ERPeducation.Command;
using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Interface.DialogPersonal;
using ERPeducation.Common.Services.ServiceForEducation;
using ERPeducation.Common.Services.ServicesForPersonalContact;
using ERPeducation.Common.Windows;
using ERPeducation.Models;
using ERPeducation.Models.AdmissionCampaign.Documents;
using ERPeducation.Models.AdmissionCampaign.EducationDocuments;
using ERPeducation.ViewModels;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.FieldOfStudy;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.PersonalInformation;
using ERPeducation.Views.AdmissionCampaign.DocumentsView;
using ERPeducation.Views.AdmissionCampaign.TabsView.TabEducation.DocumentsView;
using ReactiveUI;
using System.IO;
using System.Windows.Forms;

namespace ERPeducation.Common.Services
{
    public class DialogService : ReactiveObject, IDialogService
    {
        public string OpenPathDialog()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            FileServer.PathIS = dialog.SelectedPath;
            return FileServer.PathIS;
        }

        public string CreateBase()
        {
            IJSONService jsonService = new JSONService();

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();

            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems"));

            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration"));
            
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "Users"));
            
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "Structures"));
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "Structures", "About"));
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "Structures", "EducationalStructure"));
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "Structures", "Education"));
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "Structures", "SpaceManagement"));
            
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "DocumentManagement"));
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "AdmissionsCampaignManagement"));
            
            FileServer.PathIS = dialog.SelectedPath;

            jsonService.CreateFileJson(FileServer.Users, "Admin.json", "Администратор", "Admin", true, true, true, true, true, true);

            return FileServer.PathIS;
        }

        //ОКНО АВТОРИЗАЦИИ
        public void OpenAuthorizationWindow()
        {
            Authorization authorization = new Authorization();
            authorization.DataContext = new AuthorizationViewModel(this, new Validator.UserValidation(), new JSONService());
            authorization.Show();
        }

        //ОКНО ОСНОВНОЙ ПРОГРАММЫ
        public void OpenMainWindow(UserModel user)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = new MainWindowViewModel(new UserControlService(), mainWindow.Close, user)
            {
                RectorIsEnabled = user.RectorAccess,
                DeanRoomIsEnabled = user.DeanRoomAccess,
                TrainingDivisionIsEnabled = user.TrainingDivisionAccess,
                TeacherIsEnabled = user.TeacherAccess,
                AdmissionCampaignIsEnabled = user.AdmissionCampaignAccess,
                AdministrationIsEnabled = user.AdministrationAccess
            };
            mainWindow.Show();
        }

        public void OpenWindow(object viewModel)
        {
            if(viewModel is EnrollePersonalInformationViewModel)
            {
                Documents windowDocuments = new();
                windowDocuments.DataContext = new DocumentsViewModel(new UserControlService(), (EnrollePersonalInformationViewModel)viewModel, windowDocuments.Close);
                windowDocuments.ShowDialog();
                return;
            }
            if(viewModel is EnrolleeEducationViewModel)
            {
                Educations educations = new Educations();
                educations.DataContext = new EducationViewModel(new UserControlService(), (EnrolleeEducationViewModel)viewModel, educations.Close);
                educations.ShowDialog();
                return;
            }
            if (viewModel is FieldOfStudyViewModel)
            {
                Fields fields = new Fields();
                fields.DataContext = new FieldsViewModel(fields.Close);
                fields.ShowDialog();
                return;
            }
        }
        public void OpenWindowEditPersonalDocument(DocsBase model, EnrollePersonalInformationViewModel viewModel)
        {
            WindowDocument document = new WindowDocument();
            DocumentsViewModel documentsViewModel = new DocumentsViewModel(new UserControlService(), viewModel, document.Close);
            if (model is Passport passport)
            {
                PassportView passportView = new PassportView();
                PassportViewModel passportViewModel = new PassportViewModel(viewModel, new GetPassportService(), null);

                passportViewModel.TitleButton = "Изменить";
                passportViewModel.AddPassportCommand = new RelayCommand(() => 
                {
                    passport.IssuedBy = passportViewModel.IssuedBy;
                    passport.DateOfIssue = passportViewModel.DateOfIssue;
                    passport.DepartmentCode = passportViewModel.DepartmentCode;
                    passport.SeriesNumber = passportViewModel.SeriesNumber;

                    passport.SurName = passportViewModel.SurName;
                    passport.Name = passportViewModel.Name;
                    passport.MiddleName = passportViewModel.MiddleName;
                    passport.Gender = passportViewModel.ValueComboBox;
                    passport.DateOfBirth = passportViewModel.DateOfBirth;
                    passport.PlaceOfBirth = passportViewModel.PlaceOfBirth;

                    passport.Location = passportViewModel.Location;
                    passport.City = passportViewModel.City;
                    passport.Street = passportViewModel.Street;
                    passport.HouseNumber = passportViewModel.HouseNumber;
                    passport.Frame = passportViewModel.Frame;
                    passport.ApartmentNumber = passportViewModel.ApartmentNumber;

                    document.Close();
                });
                GetData();

                passportView.DataContext = passportViewModel;

                documentsViewModel.TypeDocument = documentsViewModel.Docs[0];
                documentsViewModel.UserControl = passportView;

                document.DataContext = documentsViewModel;
                document.ShowDialog();
                return;

                void GetData()
                {
                    passportViewModel.IssuedBy = passport.IssuedBy;
                    passportViewModel.DateOfIssue = passport.DateOfIssue;
                    passportViewModel.DepartmentCode = passport.DepartmentCode;
                    passportViewModel.SeriesNumber = passport.SeriesNumber;

                    passportViewModel.SurName = passport.SurName;
                    passportViewModel.Name = passport.Name;
                    passportViewModel.MiddleName = passport.MiddleName;
                    passportViewModel.ValueComboBox = passport.Gender;
                    passportViewModel.DateOfBirth = passport.DateOfBirth;
                    passportViewModel.PlaceOfBirth = passport.PlaceOfBirth;

                    passportViewModel.Location = passport.Location;
                    passportViewModel.City = passport.City;
                    passportViewModel.Street = passport.Street;
                    passportViewModel.HouseNumber = passport.HouseNumber;
                    passportViewModel.Frame = passport.Frame;
                    passportViewModel.ApartmentNumber = passport.ApartmentNumber;
                }
            }
            if (model is Snils snils)
            {
                SnilsView snilsView = new SnilsView();
                SnilsViewModel snilsViewModel = new SnilsViewModel(viewModel, new GetPassportService(), null);

                snilsViewModel.TitleButton = "Изменить";
                snilsViewModel.AddSnilsCommand = new RelayCommand(() =>
                {
                    snils.Number = snilsViewModel.Number;
                    snils.RegistrationDate = snilsViewModel.RegistrationDate;

                    document.Close();
                });
                GetData();

                snilsView.DataContext = snilsViewModel;
                documentsViewModel.TypeDocument = documentsViewModel.Docs[1];
                documentsViewModel.UserControl = snilsView;
                document.DataContext = documentsViewModel;
                document.ShowDialog();
                return;

                void GetData()
                {
                    snilsViewModel.Number = snils.Number;
                    snilsViewModel.RegistrationDate = snils.RegistrationDate;
                }
            }
            if (model is INN inn)
            {
                InnView innView = new InnView();
                InnViewModel innViewModel = new InnViewModel(viewModel, new GetPassportService(), null);

                innViewModel.TitleButton = "Изменить";
                innViewModel.AddInnCommand = new RelayCommand(() =>
                {
                    inn.DateOfAssignment = innViewModel.DateOfAssignment;
                    inn.NumberINN = innViewModel.NumberINN;
                    inn.Organization = innViewModel.Organization;
                    inn.SeriesNumber = innViewModel.SeriesNumber;
                    document.Close();
                });
                GetData();

                innView.DataContext = innViewModel;
                documentsViewModel.TypeDocument = documentsViewModel.Docs[2];
                documentsViewModel.UserControl = innView;
                document.DataContext = documentsViewModel;
                document.ShowDialog();
                return;

                void GetData()
                {
                    innViewModel.DateOfAssignment = inn.DateOfAssignment;
                    innViewModel.NumberINN = inn.NumberINN;
                    innViewModel.Organization = inn.Organization;
                    innViewModel.SeriesNumber = inn.SeriesNumber;
                }
            }
            if (model is ForeignPassport foreignPassport)
            {
                ForeignPassportView foreignPassportView = new ForeignPassportView();
                ForeignPassportViewModel foreignPassportViewModel = new ForeignPassportViewModel(viewModel, new GetPassportService(), null);

                foreignPassportViewModel.TitleButton = "Изменить";
                foreignPassportViewModel.AddForeignPassportCommand = new RelayCommand(() =>
                {
                    foreignPassport.Abbreviation = foreignPassportViewModel.Abbreviation;
                    foreignPassport.Number = foreignPassportViewModel.Number;
                    foreignPassport.IssuedBy = foreignPassportViewModel.IssuedBy;
                    foreignPassport.DateOfIssue = foreignPassportViewModel.DateOfIssue;
                    foreignPassport.Validity = foreignPassportViewModel.Validity;

                    foreignPassport.Gender = foreignPassportViewModel.ValueComboBox;
                    foreignPassport.SurName = foreignPassportViewModel.SurName;
                    foreignPassport.Name = foreignPassportViewModel.Name;
                    foreignPassport.MiddleName = foreignPassportViewModel.MiddleName;
                    foreignPassport.DateOfBirth = foreignPassportViewModel.DateOfBirth;
                    foreignPassport.PlaceOfBirth = foreignPassportViewModel.PlaceOfBirth;
                    foreignPassport.Citizenship = foreignPassportViewModel.Citizenship;

                    document.Close();
                });
                GetData();

                foreignPassportView.DataContext = foreignPassportViewModel;
                documentsViewModel.TypeDocument = documentsViewModel.Docs[3];
                documentsViewModel.UserControl = foreignPassportView;
                document.DataContext = documentsViewModel;
                document.ShowDialog();
                return;

                void GetData()
                {
                    foreignPassportViewModel.Abbreviation = foreignPassport.Abbreviation;
                    foreignPassportViewModel.Number = foreignPassport.Number;
                    foreignPassportViewModel.IssuedBy = foreignPassport.IssuedBy;
                    foreignPassportViewModel.DateOfIssue = foreignPassport.DateOfIssue;
                    foreignPassportViewModel.Validity = foreignPassport.Validity;

                    foreignPassportViewModel.SurName = foreignPassport.SurName;
                    foreignPassportViewModel.Name = foreignPassport.Name;
                    foreignPassportViewModel.MiddleName = foreignPassport.MiddleName;
                    foreignPassportViewModel.DateOfBirth = foreignPassport.DateOfBirth;
                    foreignPassportViewModel.ValueComboBox = foreignPassport.Gender;
                    foreignPassportViewModel.PlaceOfBirth = foreignPassport.PlaceOfBirth;
                    foreignPassport.Citizenship = foreignPassport.Citizenship;
                }
            }
        }
        public void OpenWindowEditEducationDocument(TypeEducationBaseModel model, EnrolleeEducationViewModel viewModel, int selectedItemInt)
        {
            WindowEducation education = new WindowEducation();
            EducationViewModel educationViewModel = new EducationViewModel(new UserControlService(), viewModel, education.Close);
            if(model is CertificateModel certificate && certificate.TypeEducation == "Основное общее")
            {
                Certificate certificateView = new Certificate();
                CertificateViewModel certificateViewModel = new CertificateViewModel(null, null, null, null);

                certificateViewModel.TitileButton = "Изменить";
                viewModel.SelectedEducation = null;
                certificateViewModel.AddEducation = ReactiveCommand.Create(() => 
                {
                    certificate.TypeEducation = "Основное общее";
                    certificate.TypeEducationDocument = certificateViewModel.TypeEducationDocument;
                    certificate.IsBool = certificateViewModel.IsBool;
                    certificate.DateOfIssue = certificateViewModel.DateOfIssue;
                    certificate.IssuedBy = certificateViewModel.IssuedBy;
                    certificate.NumberCertificate = certificateViewModel.NumberCertificate;

                    viewModel.SelectedEducation = viewModel.Education[selectedItemInt];

                    education.Close();
                });

                GetData();

                certificateView.DataContext = certificateViewModel;

                educationViewModel.TypeDocument = educationViewModel.EducationLevels[0];
                educationViewModel.UserControl = certificateView;

                education.DataContext = educationViewModel;
                education.ShowDialog();
                return;

                void GetData()
                {
                    certificateViewModel.TypeEducation = certificate.TypeEducation;
                    certificateViewModel.TypeEducationDocument = certificate.TypeEducationDocument;
                    certificateViewModel.IsBool = certificate.IsBool;
                    certificateViewModel.DateOfIssue = certificate.DateOfIssue;
                    certificateViewModel.IssuedBy = certificate.IssuedBy;
                    certificateViewModel.NumberCertificate = certificate.NumberCertificate;
                }
            }
            else if(model is CertificateModel certificateAdditional && certificateAdditional.TypeEducation == "Среднее общее")
            {
                Certificate certificateView = new Certificate();
                CertificateViewModel certificateViewModel = new CertificateViewModel(new GetCertificateService(), 
                    "Аттестат о Среднем общем образовании", null, null);

                certificateViewModel.TitileButton = "Изменить";
                viewModel.SelectedEducation = null;
                certificateViewModel.AddEducation = ReactiveCommand.Create(() =>
                {
                    certificateAdditional.TypeEducation = "Среднее общее";
                    certificateAdditional.TypeEducationDocument = certificateViewModel.TypeEducationDocument;
                    certificateAdditional.IsBool = certificateViewModel.IsBool;
                    certificateAdditional.DateOfIssue = certificateViewModel.DateOfIssue;
                    certificateAdditional.IssuedBy = certificateViewModel.IssuedBy;
                    certificateAdditional.NumberCertificate = certificateViewModel.NumberCertificate;

                    viewModel.SelectedEducation = viewModel.Education[selectedItemInt];

                    education.Close();
                });
                GetData();

                certificateView.DataContext = certificateViewModel;

                educationViewModel.TypeDocument = educationViewModel.EducationLevels[1];
                educationViewModel.UserControl = certificateView;

                education.DataContext = educationViewModel;
                education.ShowDialog();
                return;

                void GetData()
                {
                    certificateViewModel.TypeEducation = "Аттестат о Среднем общем образовании";
                    certificateViewModel.TypeEducationDocument = certificateAdditional.TypeEducationDocument;
                    certificateViewModel.IsBool = certificateAdditional.IsBool;
                    certificateViewModel.DateOfIssue = certificateAdditional.DateOfIssue;
                    certificateViewModel.IssuedBy = certificateAdditional.IssuedBy;
                    certificateViewModel.NumberCertificate = certificateAdditional.NumberCertificate;
                }
            }

            if(model is DiplomaModel diplomaSPO && diplomaSPO.TypeEducation == "Среднее профессиональное")
            {
                Diploma diplomaView = new Diploma();
                DiplomaViewModel diplomaViewModel = new DiplomaViewModel(new GetCertificateService(), 
                    "Диплом о Среднем профессиональном образовании", null, null);

                diplomaViewModel.TitileButton = "Изменить";
                viewModel.SelectedEducation = null;
                diplomaViewModel.AddEducation = new RelayCommand(() => 
                {
                    diplomaSPO.TypeEducation = "Среднее профессиональное";
                    diplomaSPO.TypeEducationDocument = diplomaViewModel.TypeEducationDocument;
                    diplomaSPO.IsBool = diplomaViewModel.IsBool;
                    diplomaSPO.DateOfIssue = diplomaViewModel.DateOfIssue;
                    diplomaSPO.IssuedBy = diplomaViewModel.IssuedBy;
                    diplomaSPO.NumberDiploma = diplomaViewModel.NumberDiploma;
                    diplomaSPO.RegistrationNumber = diplomaViewModel.RegistrationNumber;
                    diplomaSPO.Qualification = diplomaViewModel.Qualification;
                    diplomaSPO.AdditionalNumberDiploma = diplomaViewModel.AdditionalNumberDiploma;

                    viewModel.SelectedEducation = viewModel.Education[selectedItemInt];

                    education.Close();
                });
                GetData();

                diplomaView.DataContext = diplomaViewModel;

                educationViewModel.TypeDocument = educationViewModel.EducationLevels[2];
                educationViewModel.UserControl = diplomaView;

                education.DataContext = educationViewModel;
                education.ShowDialog();
                return;

                void GetData()
                {
                    diplomaViewModel.TypeEducation = "Диплом о Среднем профессиональном образовании";
                    diplomaViewModel.TypeEducationDocument = diplomaSPO.TypeEducationDocument;
                    diplomaViewModel.IsBool = diplomaSPO.IsBool;
                    diplomaViewModel.DateOfIssue = diplomaSPO.DateOfIssue;
                    diplomaViewModel.IssuedBy = diplomaSPO.IssuedBy;
                    diplomaViewModel.NumberDiploma = diplomaSPO.NumberDiploma;
                    diplomaViewModel.RegistrationNumber = diplomaSPO.RegistrationNumber;
                    diplomaViewModel.Qualification = diplomaSPO.Qualification;
                    diplomaViewModel.AdditionalNumberDiploma = diplomaSPO.AdditionalNumberDiploma;
                }
            }
            else if (model is DiplomaModel diplomaBac && diplomaBac.TypeEducation == "Бакалавриат")
            {
                Diploma diplomaView = new Diploma();
                DiplomaViewModel diplomaViewModel = new DiplomaViewModel(new GetCertificateService(), 
                    "Диплом Бакалавра", null, null);

                diplomaViewModel.TitileButton = "Изменить";
                viewModel.SelectedEducation = null;
                diplomaViewModel.AddEducation = new RelayCommand(() =>
                {
                    diplomaBac.TypeEducation = "Бакалавриат";
                    diplomaBac.TypeEducationDocument = diplomaViewModel.TypeEducationDocument;
                    diplomaBac.IsBool = diplomaViewModel.IsBool;
                    diplomaBac.DateOfIssue = diplomaViewModel.DateOfIssue;
                    diplomaBac.IssuedBy = diplomaViewModel.IssuedBy;
                    diplomaBac.NumberDiploma = diplomaViewModel.NumberDiploma;
                    diplomaBac.RegistrationNumber = diplomaViewModel.RegistrationNumber;
                    diplomaBac.Qualification = diplomaViewModel.Qualification;
                    diplomaBac.AdditionalNumberDiploma = diplomaViewModel.AdditionalNumberDiploma;

                    viewModel.SelectedEducation = viewModel.Education[selectedItemInt];

                    education.Close();
                });
                GetData();

                diplomaView.DataContext = diplomaViewModel;

                educationViewModel.TypeDocument = educationViewModel.EducationLevels[3];
                educationViewModel.UserControl = diplomaView;

                education.DataContext = educationViewModel;
                education.ShowDialog();
                return;

                void GetData()
                {
                    diplomaViewModel.TypeEducation = "Диплом Бакалавра";
                    diplomaViewModel.TypeEducation = diplomaBac.TypeEducationDocument;
                    diplomaViewModel.IsBool = diplomaBac.IsBool;
                    diplomaViewModel.DateOfIssue = diplomaBac.DateOfIssue;
                    diplomaViewModel.IssuedBy = diplomaBac.IssuedBy;
                    diplomaViewModel.NumberDiploma = diplomaBac.NumberDiploma;
                    diplomaViewModel.RegistrationNumber = diplomaBac.RegistrationNumber;
                    diplomaViewModel.Qualification = diplomaBac.Qualification;
                    diplomaViewModel.AdditionalNumberDiploma = diplomaBac.AdditionalNumberDiploma;
                }
            }
            else if (model is DiplomaModel diplomaMag && diplomaMag.TypeEducation == "Магистратура")
            {
                Diploma diplomaView = new Diploma();
                DiplomaViewModel diplomaViewModel = new DiplomaViewModel(new GetCertificateService(), 
                    "Диплом Магистра", null, null);

                diplomaViewModel.TitileButton = "Изменить";
                viewModel.SelectedEducation = null;
                diplomaViewModel.AddEducation = new RelayCommand(() =>
                {
                    diplomaMag.TypeEducation = "Магистратура";
                    diplomaMag.TypeEducationDocument = diplomaViewModel.TypeEducationDocument;
                    diplomaMag.IsBool = diplomaViewModel.IsBool;
                    diplomaMag.DateOfIssue = diplomaViewModel.DateOfIssue;
                    diplomaMag.IssuedBy = diplomaViewModel.IssuedBy;
                    diplomaMag.NumberDiploma = diplomaViewModel.NumberDiploma;
                    diplomaMag.RegistrationNumber = diplomaViewModel.RegistrationNumber;
                    diplomaMag.Qualification = diplomaViewModel.Qualification;
                    diplomaMag.AdditionalNumberDiploma = diplomaViewModel.AdditionalNumberDiploma;

                    viewModel.SelectedEducation = viewModel.Education[selectedItemInt];

                    education.Close();
                });
                GetData();

                diplomaView.DataContext = diplomaViewModel;

                educationViewModel.TypeDocument = educationViewModel.EducationLevels[4];
                educationViewModel.UserControl = diplomaView;

                education.DataContext = educationViewModel;
                education.ShowDialog();
                return;

                void GetData()
                {
                    diplomaViewModel.TypeEducation = "Диплом Магистра";
                    diplomaViewModel.TypeEducationDocument = diplomaMag.TypeEducationDocument;
                    diplomaViewModel.IsBool = diplomaMag.IsBool;
                    diplomaViewModel.DateOfIssue = diplomaMag.DateOfIssue;
                    diplomaViewModel.IssuedBy = diplomaMag.IssuedBy;
                    diplomaViewModel.NumberDiploma = diplomaMag.NumberDiploma;
                    diplomaViewModel.RegistrationNumber = diplomaMag.RegistrationNumber;
                    diplomaViewModel.Qualification = diplomaMag.Qualification;
                    diplomaViewModel.AdditionalNumberDiploma = diplomaMag.AdditionalNumberDiploma;
                }
            }
            else if (model is DiplomaModel diplomaAsp && diplomaAsp.TypeEducation == "Аспирантура")
            {
                Diploma diplomaView = new Diploma();
                DiplomaViewModel diplomaViewModel = new DiplomaViewModel(new GetCertificateService(), 
                    "Диплом об окончании Аспирантуры", null, null);

                diplomaViewModel.TitileButton = "Изменить";
                viewModel.SelectedEducation = null;
                diplomaViewModel.AddEducation = new RelayCommand(() =>
                {
                    diplomaAsp.TypeEducation = "Аспирантура";
                    diplomaAsp.TypeEducationDocument = diplomaViewModel.TypeEducationDocument;
                    diplomaAsp.IsBool = diplomaViewModel.IsBool;
                    diplomaAsp.DateOfIssue = diplomaViewModel.DateOfIssue;
                    diplomaAsp.IssuedBy = diplomaViewModel.IssuedBy;
                    diplomaAsp.NumberDiploma = diplomaViewModel.NumberDiploma;
                    diplomaAsp.RegistrationNumber = diplomaViewModel.RegistrationNumber;
                    diplomaAsp.Qualification = diplomaViewModel.Qualification;
                    diplomaAsp.AdditionalNumberDiploma = diplomaViewModel.AdditionalNumberDiploma;

                    viewModel.SelectedEducation = viewModel.Education[selectedItemInt];

                    education.Close();
                });
                GetData();

                diplomaView.DataContext = diplomaViewModel;

                educationViewModel.TypeDocument = educationViewModel.EducationLevels[5];
                educationViewModel.UserControl = diplomaView;

                education.DataContext = educationViewModel;
                education.ShowDialog();
                return;

                void GetData()
                {
                    diplomaViewModel.TypeEducation = "Диплом об окончании Аспирантуры";
                    diplomaViewModel.TypeEducationDocument = diplomaAsp.TypeEducationDocument;
                    diplomaViewModel.IsBool = diplomaAsp.IsBool;
                    diplomaViewModel.DateOfIssue = diplomaAsp.DateOfIssue;
                    diplomaViewModel.IssuedBy = diplomaAsp.IssuedBy;
                    diplomaViewModel.NumberDiploma = diplomaAsp.NumberDiploma;
                    diplomaViewModel.RegistrationNumber = diplomaAsp.RegistrationNumber;
                    diplomaViewModel.Qualification = diplomaAsp.Qualification;
                    diplomaViewModel.AdditionalNumberDiploma = diplomaAsp.AdditionalNumberDiploma;
                }
            }
        }
    }
}