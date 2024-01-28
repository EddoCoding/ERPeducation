using ERPeducation.ViewModels.Modules.Administration;

namespace ERPeducation.Common.Interface
{
    public interface IDialogError
    {
        public void OpenDialogError();
        public void OpenNotification(AdministrationStructViewModel viewModel);
    }
}
