using ERPeducation.Common.Interface;
using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Windows.WindowSubmitted
{
    public class DialogSubmitted : IDialogSubmitted
    {
        public void GetSubmitted(ObservableCollection<ISubmitted> submitted)
        {
            SubmittedView view = new SubmittedView();
            view.DataContext = new SubmittedViewModel(submitted, view.Close);
            view.ShowDialog();
        }
    }
}
