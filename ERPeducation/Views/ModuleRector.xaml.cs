using System.Windows.Controls;

namespace ERPeducation.Views
{

    public partial class ModuleRector : UserControl
    {
        public ModuleRector(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
