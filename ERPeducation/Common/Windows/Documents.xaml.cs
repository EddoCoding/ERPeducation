using System.Windows;
using System.Windows.Controls;

namespace ERPeducation.Common.Windows
{
    public partial class Documents : Window
    {
        public Documents(UserControl view, object viewModel)
        {
            InitializeComponent();
            Content = view;
            view.DataContext = viewModel;
        }
    }
}
