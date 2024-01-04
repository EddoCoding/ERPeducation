using ERPeducation.ViewModels;
using System.Windows;

namespace ERPeducation
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            new MainWindow() { DataContext = new MainWindowViewModel(() => MainWindow.Close(), "Admin", "Администратор") }.Show(); 
            //потом перенести в метод входа из окна логинапароля
        }
    }
}