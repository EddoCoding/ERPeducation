using System.Windows.Controls;

namespace ERPeducation.Views
{
    public partial class ModuleAdministration : UserControl
    {
        public ModuleAdministration(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
