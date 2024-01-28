using ERPeducation.Common.Interface.DialogPersonal;
using ERPeducation.Common.Services;
using System.Windows;

namespace ERPeducation
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IDialogService dialogService = new DialogService();
            dialogService.OpenMainWindow();
        }
    }
}