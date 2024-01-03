using System.Windows.Controls;

namespace ERPeducation.Views.AdmissionCampaign.DocumentsView
{
    public partial class ForeignPassportView : UserControl
    {
        public ForeignPassportView(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
