using ERPeducation.Common.Interface;
using ERPeducation.Common.Windows;
using ERPeducation.ViewModels;
using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel;
using ERPeducation.Views;
using ERPeducation.Views.AdmissionCampaign;
using ERPeducation.Views.AdmissionCampaign.DocumentsView;
using ERPeducation.Views.ModuleEnrolle;
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

        public void OpenWindow(EnrollePersonalInformationViewModel documents)
        {
            Documents windowDocuments = new();
            windowDocuments.DataContext = new DocumentsViewModel(this, documents, windowDocuments.Close);
            windowDocuments.Show();
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
                    break;
                case "Образование":
                    break;
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

        public UserControl GetUserControlForDocuments(string? documents, EnrollePersonalInformationViewModel viewModel)
        {
            switch (documents)
            {
                case "Паспорт":
                    PassportView passportView = new PassportView();
                    passportView.DataContext = new PassportViewModel(viewModel, new GetPassportService());
                    return passportView;
                case "СНИЛС":
                    SnilsView snilsView = new SnilsView();
                    snilsView.DataContext = new SnilsViewModel(viewModel, new GetSnilsService());
                    return snilsView;
                case "ИНН":
                    InnView innView = new InnView();
                    innView.DataContext = new InnViewModel(viewModel, new GetInnService());
                    return innView;
                case "Иностранный паспорт":
                    ForeignPassportView foreignPassportView = new ForeignPassportView();
                    foreignPassportView.DataContext = new ForeignPassportViewModel(viewModel, new GetForeignPassportService());
                    return foreignPassportView;
            }
            
            return null;
        }
    }
}