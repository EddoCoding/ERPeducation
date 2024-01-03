using System.Windows.Controls;

namespace ERPeducation.Views.AdmissionCampaign.DocumentsView
{
    public partial class SnilsView : UserControl
    {
        public SnilsView(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
