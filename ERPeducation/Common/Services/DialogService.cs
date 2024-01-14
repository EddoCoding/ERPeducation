using ERPeducation.Command;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Windows;
using ERPeducation.Models.AdmissionCampaign.Documents;
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
                    enrolleeEducationView.DataContext = new EnrolleeEducationViewModel(this);
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

        public void ShowUserControlDocumentsForEdit(DocsBase userControl, EnrollePersonalInformationViewModel viewModel)
        {
            WindowDocument document = new WindowDocument();
            DocumentsViewModel documentsViewModel = new DocumentsViewModel(this, viewModel, document.Close);
            if (userControl is Passport passport)
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
            if (userControl is Snils snils)
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
            if (userControl is INN inn)
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
            if (userControl is ForeignPassport foreignPassport)
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
    }
}