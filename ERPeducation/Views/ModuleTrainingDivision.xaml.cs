using System.Windows.Controls;

namespace ERPeducation.Views
{

    public partial class ModuleTrainingDivision : UserControl
    {
        public ModuleTrainingDivision(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
