using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;
using ERPeducation.Common.Windows;
using ERPeducation.ViewModels;
using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel;
using ERPeducation.Views;
using ERPeducation.Views.AdmissionCampaign;
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
            windowDocuments.DataContext = new DocumentsViewModel(documents, windowDocuments.Close);
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

        public UserControl GetUserControl(string line)
        {
            if(line == "Абитуриент")
            {
                ModuleEnrollee moduleEnrollee = new ModuleEnrollee();
                moduleEnrollee.DataContext = new EnrolleeViewModel(this);
                return moduleEnrollee;
            }

            switch (line)
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
    }
}
//UserControl[] userControls = new UserControl[]
//new EnrollePersonalInformationView(new EnrollePersonalInformationViewModel(new DialogService()))