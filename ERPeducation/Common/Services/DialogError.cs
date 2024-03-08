using ERPeducation.Common.Interface;
using ERPeducation.Common.Windows.WindowError;

namespace ERPeducation.Common.Services
{
    public class DialogError : IDialogError
    {
        public void Error(string error)
        {
            Error errorDialog = new Error();
            errorDialog.DataContext = new ErrorViewModel(error, errorDialog.Close);
            errorDialog.ShowDialog();
        }
    }
}