using System.Windows.Controls;

namespace ERPeducation.Views.AdmissionCampaign.DocumentsView
{
    public partial class InnView : UserControl
    {
        public InnView(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
