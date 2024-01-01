using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using System.Windows.Controls;

namespace ERPeducation.Views.ModuleEnrolle
{
    public partial class EnrollePersonalInformationView : UserControl
    {
        public EnrollePersonalInformationView(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
