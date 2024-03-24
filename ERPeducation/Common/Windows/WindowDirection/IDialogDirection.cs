using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.Common.Windows.WindowDirection
{
    public interface IDialogDirection
    {
        void GetDirection(ObservableCollection<DirectionViewModel> directions);
        void GetDirection(DirectionViewModel directions);
        void GetUserControlDirection(UserControl userControl, DirectionViewModel direction);
    }
}