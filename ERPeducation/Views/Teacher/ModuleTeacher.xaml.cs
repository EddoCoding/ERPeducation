using System.Windows.Controls;

namespace ERPeducation.Views
{
    public partial class ModuleTeacher : UserControl
    {
        public ModuleTeacher(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}