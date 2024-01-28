using ERPeducation.Common.Interface;
using ERPeducation.Common.Windows;
using ERPeducation.ViewModels.Modules.Administration;

namespace ERPeducation.Common.Services
{
    public class DialogError : IDialogError
    {
        public void OpenDialogError()
        {
            
        }

        public void OpenNotification(AdministrationStructViewModel viewModel)
        {
            Notification notification = new Notification();
            notification.DataContext = new NotificationViewModel(viewModel, notification.Close);
            notification.ShowDialog();
        }
    }
}
