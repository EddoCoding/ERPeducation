using System.Windows.Controls;

namespace ERPeducation.Views
{
    public partial class ModuleDeanRoom : UserControl
    {
        public ModuleDeanRoom(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
