using System.Windows.Controls;

namespace ERPeducation.Views.AdmissionCampaign.DocumentsView
{
    public partial class PassportView : UserControl
    {
        public PassportView(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
