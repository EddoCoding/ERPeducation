using ERPeducation.Common.Windows.WindowTest;
using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using ERPeducation.Views.AdmissionCampaign.UserControlDirection;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.Common.Windows.WindowDirection
{
    public class DialogDirection : IDialogDirection
    {
        public void GetDirection(ObservableCollection<DirectionViewModel> directions)
        {
            DirectionView view = new DirectionView();
            view.DataContext = new DirectionViewModel(this, new DialogTest(), directions, view.Close);
            view.ShowDialog();
        }

        public void GetDirection(DirectionViewModel directions)
        {
            DirectionView view = new DirectionView();
            view.DataContext = new DirectionViewModel(directions, view.Close);
            view.ShowDialog();
        }

        public void GetUserControlDirection(UserControl userControl, DirectionViewModel direction) =>
            userControl.Content = new DirectionUserControl() { DataContext = direction };
    }
}