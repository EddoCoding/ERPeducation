using ERPeducation.Common.Interface;
using ERPeducation.Common.Services.ServiceForEducation;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel;
using ERPeducation.Views.AdmissionCampaign.TabsView.TabEducation.DocumentsView;
using System.Windows.Controls;
using System;
using ERPeducation.Common.Services.ServicesForPersonalContact;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.PersonalInformation;
using ERPeducation.Views.AdmissionCampaign.DocumentsView;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.ContactInformation;
using ERPeducation.Views.AdmissionCampaign.Tabs;
using ERPeducation.Views.AdmissionCampaign.TabsView;
using ERPeducation.Views.ModuleEnrolle;
using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using ERPeducation.Views;
using ERPeducation.ViewModels;
using ERPeducation.Views.AdmissionCampaign;
using ERPeducation.Views.AdmissionCampaign.TabsView.FieldOfStudy;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.FieldOfStudy;
using ERPeducation.ViewModels.Modules.Administration;
using ERPeducation.Views.Administration;

namespace ERPeducation.Common.Services
{
    public class UserControlService : IUserControlService
    {
        public UserControl GetUserControl(string? titleButton, object viewModel)
        {
            switch (titleButton)
            {
                case "Приёмная кампания":
                    AdmissionCampaign admissionCampaign = new AdmissionCampaign();
                    admissionCampaign.DataContext = new AdmissionCampaignViewModel(this, (MainWindowViewModel)viewModel);
                    return admissionCampaign;
                case "Администрирование":
                    ModuleAdministration moduleAdministration = new ModuleAdministration();
                    moduleAdministration.DataContext = new AdministrationViewModel(this);
                    return moduleAdministration;
            }
            return null;
        } //Для главных модулей

        public UserControl GetUserControlForAdmissionCampaign(string TitleTab)
        {
            if (TitleTab == "Абитуриент")
            {
                ModuleEnrollee moduleEnrollee = new ModuleEnrollee();
                moduleEnrollee.DataContext = new EnrolleeViewModel(this);
                return moduleEnrollee;
            }

            return null;
        } //Модуль Абитуриент

        public UserControl GetUserControlForModuleEnrollee(string moduleEnrolle)
        {
            switch (moduleEnrolle)
            {
                case "Личная информация":
                    EnrollePersonalInformationView enrollePersonalInformationView = new EnrollePersonalInformationView();
                    enrollePersonalInformationView.DataContext = new EnrollePersonalInformationViewModel(new DialogService());
                    return enrollePersonalInformationView;
                case "Контактная информация":
                    EnrolleeContactInformationView enrolleeContactInformationView = new EnrolleeContactInformationView();
                    enrolleeContactInformationView.DataContext = new EnrolleeContactInforamationViewModel();
                    return enrolleeContactInformationView;
                case "Образование":
                    EnrolleeEducationView enrolleeEducationView = new EnrolleeEducationView();
                    enrolleeEducationView.DataContext = new EnrolleeEducationViewModel(new DialogService(), new EducationInformationService());
                    return enrolleeEducationView;
                case "Направление подготовки":
                    FieldOfStudyView fieldOfStudyView = new FieldOfStudyView();
                    fieldOfStudyView.DataContext = new FieldOfStudyViewModel(new DialogService());
                    return fieldOfStudyView;
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
        } //Вкладки модуля Абитуриент

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
        } //Личные документы Абитуриента

        public UserControl GetUserControlForTypeEducationDocument(string typeEducation, EnrolleeEducationViewModel viewModel, Action closeWindow)
        {
            switch (typeEducation)
            {
                case "Основное общее":
                    return new Certificate()
                    {
                        DataContext = new CertificateViewModel(new GetCertificateService(),
                        "Аттестат об Основном общем образовании", viewModel, closeWindow)
                    };
                case "Среднее общее":
                    return new Certificate()
                    {
                        DataContext = new CertificateViewModel(new GetCertificateService(),
                        "Аттестат о Среднем общем образовании", viewModel, closeWindow)
                    };
                case "Среднее профессиональное":
                    return new Diploma()
                    {
                        DataContext = new DiplomaViewModel(new GetDiplomaService(),
                        "Диплом о Среднем профессиональном образовании", viewModel, closeWindow)
                    };
                case "Бакалавриат":
                    return new Diploma()
                    {
                        DataContext = new DiplomaViewModel(new GetDiplomaService(),
                        "Диплом Бакалавра", viewModel, closeWindow)
                    };
                case "Магистратура":
                    return new Diploma()
                    {
                        DataContext = new DiplomaViewModel(new GetDiplomaService(),
                        "Диплом Магистра", viewModel, closeWindow)
                    };
                case "Аспирантура":
                    return new Diploma()
                    {
                        DataContext = new DiplomaViewModel(new GetDiplomaService(),
                        "Диплом об окончании Аспирантуры", viewModel, closeWindow)
                    };
            }

            return null;
        } //Документы об образовании Абитуриента

        public UserControl GetUserControlForAdministrationView() =>
            new AdministrationUsersView() { DataContext = new AdministrationUserViewModel(new DialogService(), new JSONService()) };
        public UserControl GetUserControlForAdministrationStruct() => 
            new AdministrationStructView() { DataContext = new AdministrationStructViewModel(new JSONService()) };
    }
}