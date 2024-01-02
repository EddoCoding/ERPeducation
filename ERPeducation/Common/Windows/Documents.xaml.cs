using System.Windows;

namespace ERPeducation.Common.Windows
{
    public partial class Documents : Window
    {
        public Documents(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
