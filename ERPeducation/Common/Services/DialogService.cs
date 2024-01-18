using ERPeducation.Command;
using ERPeducation.Common.Interface.DialogPersonal;
using ERPeducation.Common.Services.ServiceForEducation;
using ERPeducation.Common.Services.ServicesForPersonalContact;
using ERPeducation.Common.Windows;
using ERPeducation.Models.AdmissionCampaign.Documents;
using ERPeducation.Models.AdmissionCampaign.EducationDocuments;
using ERPeducation.ViewModels;
using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.ContactInformation;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.PersonalInformation;
using ERPeducation.Views;
using ERPeducation.Views.AdmissionCampaign;
using ERPeducation.Views.AdmissionCampaign.DocumentsView;
using ERPeducation.Views.AdmissionCampaign.Tabs;
using ERPeducation.Views.AdmissionCampaign.TabsView;
using ERPeducation.Views.AdmissionCampaign.TabsView.TabEducation.DocumentsView;
using ERPeducation.Views.ModuleEnrolle;
using System;
using System.Windows.Controls;

namespace ERPeducation.Common.Services
{
    public class DialogService : IDialogService
    {
        public void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = new MainWindowViewModel(this, mainWindow.Close, "Admin", "Администратор");
            mainWindow.Show();
        }

        public void OpenWindow(object viewModel)
        {
            if(viewModel is EnrollePersonalInformationViewModel)
            {
                Documents windowDocuments = new();
                windowDocuments.DataContext = new DocumentsViewModel(this, (EnrollePersonalInformationViewModel)viewModel, windowDocuments.Close);
                windowDocuments.ShowDialog();
            }
            if(viewModel is EnrolleeEducationViewModel)
            {
                Educations educations = new Educations();
                educations.DataContext = new EducationViewModel(this, (EnrolleeEducationViewModel)viewModel, educations.Close);
                educations.ShowDialog();
            }
        }

        public UserControl GetUserControl(string? titleButton, object viewModel)
        {
            switch (titleButton)
            {
                case "Приёмная кампания":
                    AdmissionCampaign admissionCampaign = new AdmissionCampaign();
                    admissionCampaign.DataContext = new AdmissionCampaignViewModel(this, (MainWindowViewModel)viewModel);
                    return admissionCampaign;
            }
            return null;
        }

        public UserControl GetUserControlForAdmissionCampaign(string TitleTab)
        {
            if(TitleTab == "Абитуриент")
            {
                ModuleEnrollee moduleEnrollee = new ModuleEnrollee();
                moduleEnrollee.DataContext = new EnrolleeViewModel(this);
                return moduleEnrollee;
            }

            return null;
        }

        public UserControl GetUserControlForModuleEnrollee(string moduleEnrolle)
        {
            switch (moduleEnrolle)
            {
                case "Личная информация":
                    EnrollePersonalInformationView enrollePersonalInformationView = new EnrollePersonalInformationView();
                    enrollePersonalInformationView.DataContext = new EnrollePersonalInformationViewModel(this);
                    return enrollePersonalInformationView;
                case "Контактная информация":
                    EnrolleeContactInformationView enrolleeContactInformationView = new EnrolleeContactInformationView();
                    enrolleeContactInformationView.DataContext = new EnrolleeContactInforamationViewModel();
                    return enrolleeContactInformationView;
                case "Образование":
                    EnrolleeEducationView enrolleeEducationView = new EnrolleeEducationView();
                    enrolleeEducationView.DataContext = new EnrolleeEducationViewModel(this, new EducationInformationService());
                    return enrolleeEducationView;
                case "Направление подготовки":
                    break;
                case "Поданные документы":
                    break;
                case "Результаты испытаний":
                    break;
                case "Заключить договор":
                    break;
                case "Дело":
                    break;
                case "Печать":
                    break;
            }

            return null;
        }

        public UserControl GetUserControlForDocuments(string? documents, EnrollePersonalInformationViewModel viewModel, Action closeWindow)
        {
            switch (documents)
            {
                case "Паспорт":
                    PassportView passportView = new PassportView();
                    passportView.DataContext = new PassportViewModel(viewModel, new GetPassportService(), closeWindow);
                    return passportView;
                case "СНИЛС":
                    SnilsView snilsView = new SnilsView();
                    snilsView.DataContext = new SnilsViewModel(viewModel, new GetSnilsService(), closeWindow);
                    return snilsView;
                case "ИНН":
                    InnView innView = new InnView();
                    innView.DataContext = new InnViewModel(viewModel, new GetInnService(), closeWindow);
                    return innView;
                case "Иностранный паспорт":
                    ForeignPassportView foreignPassportView = new ForeignPassportView();
                    foreignPassportView.DataContext = new ForeignPassportViewModel(viewModel, new GetForeignPassportService(), closeWindow);
                    return foreignPassportView;
            }
            
            return null;
        }

        public void ShowUserControlDocumentsForEdit(DocsBase model, EnrollePersonalInformationViewModel viewModel)
        {
            WindowDocument document = new WindowDocument();
            DocumentsViewModel documentsViewModel = new DocumentsViewModel(this, viewModel, document.Close);
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

        public UserControl GetUserControlForTypeEducationDocument(string typeEducation, EnrolleeEducationViewModel viewModel, Action closeWindow)
        {
            switch (typeEducation)
            {
                case "Основное общее": 
                    return new Certificate() { DataContext = new CertificateViewModel(new GetCertificateService(), 
                        "Аттестат об Основном общем образовании", viewModel, closeWindow)
                    };
                case "Среднее общее":
                    return new Certificate() { DataContext = new CertificateViewModel(new GetCertificateService(), 
                        "Аттестат о Среднем общем образовании", viewModel, closeWindow)
                    };
                case "Среднее профессиональное":
                    return new Diploma() { DataContext = new DiplomaViewModel(new GetDiplomaService(), 
                        "Диплом о Среднем профессиональном образовании", viewModel, closeWindow)};
                case "Бакалавриат":
                    return new Diploma() { DataContext = new DiplomaViewModel(new GetDiplomaService(), 
                        "Диплом Бакалавра", viewModel, closeWindow)
                    };
                case "Магистратура":
                    return new Diploma() { DataContext = new DiplomaViewModel(new GetDiplomaService(), 
                        "Диплом Магистра", viewModel, closeWindow)
                    };
                case "Аспирантура":
                    return new Diploma() { DataContext = new DiplomaViewModel(new GetDiplomaService(), 
                        "Диплом об окончании Аспирантуры", viewModel, closeWindow)
                    };
            }

            return null;
        }

        public void ShowUserControlEducationDocumentsForEdit(TypeEducationBaseModel model, EnrolleeEducationViewModel viewModel)
        {
            WindowEducation education = new WindowEducation();
            EducationViewModel educationViewModel = new EducationViewModel(this, viewModel, education.Close);
            if(model is CertificateModel certificate && certificate.TypeEducation == "Основное общее")
            {
                Certificate certificateView = new Certificate();
                CertificateViewModel certificateViewModel = new CertificateViewModel(new GetCertificateService(), 
                    "Аттестат об Основном общем образовании", null, null);

                certificateViewModel.TitileButton = "Изменить";
                certificateViewModel.AddEducation = new RelayCommand(() => 
                {
                    certificate.TypeEducation = "Основное общее";
                    certificate.TypeEducationDocument = certificateViewModel.TypeEducationDocument;
                    certificate.IsBool = certificateViewModel.IsBool;
                    certificate.DateOfIssue = certificateViewModel.DateOfIssue;
                    certificate.IssuedBy = certificateViewModel.IssuedBy;
                    certificate.NumberCertificate = certificateViewModel.NumberCertificate;

                    education.Close();
                });
                GetData();

                certificateView.DataContext = certificateViewModel;

                educationViewModel.TypeDocument = educationViewModel.EducationLevels[0];
                educationViewModel.UserControl = certificateView;

                education.DataContext = educationViewModel;
                education.ShowDialog();

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
                certificateViewModel.AddEducation = new RelayCommand(() =>
                {
                    certificateAdditional.TypeEducation = "Среднее общее";
                    certificateAdditional.TypeEducationDocument = certificateViewModel.TypeEducationDocument;
                    certificateAdditional.IsBool = certificateViewModel.IsBool;
                    certificateAdditional.DateOfIssue = certificateViewModel.DateOfIssue;
                    certificateAdditional.IssuedBy = certificateViewModel.IssuedBy;
                    certificateAdditional.NumberCertificate = certificateViewModel.NumberCertificate;

                    education.Close();
                });
                GetData();

                certificateView.DataContext = certificateViewModel;

                educationViewModel.TypeDocument = educationViewModel.EducationLevels[1];
                educationViewModel.UserControl = certificateView;

                education.DataContext = educationViewModel;
                education.ShowDialog();

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

                    education.Close();
                });
                GetData();

                diplomaView.DataContext = diplomaViewModel;

                educationViewModel.TypeDocument = educationViewModel.EducationLevels[2];
                educationViewModel.UserControl = diplomaView;

                education.DataContext = educationViewModel;
                education.ShowDialog();

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

                    education.Close();
                });
                GetData();

                diplomaView.DataContext = diplomaViewModel;

                educationViewModel.TypeDocument = educationViewModel.EducationLevels[3];
                educationViewModel.UserControl = diplomaView;

                education.DataContext = educationViewModel;
                education.ShowDialog();

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

                    education.Close();
                });
                GetData();

                diplomaView.DataContext = diplomaViewModel;

                educationViewModel.TypeDocument = educationViewModel.EducationLevels[4];
                educationViewModel.UserControl = diplomaView;

                education.DataContext = educationViewModel;
                education.ShowDialog();

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

                    education.Close();
                });
                GetData();

                diplomaView.DataContext = diplomaViewModel;

                educationViewModel.TypeDocument = educationViewModel.EducationLevels[5];
                educationViewModel.UserControl = diplomaView;

                education.DataContext = educationViewModel;
                education.ShowDialog();

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