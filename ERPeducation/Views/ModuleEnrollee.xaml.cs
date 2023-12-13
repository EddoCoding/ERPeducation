using System.Windows.Controls;

namespace ERPeducation.Views
{
    public partial class ModuleEnrollee : UserControl
    {
        public ModuleEnrollee(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
