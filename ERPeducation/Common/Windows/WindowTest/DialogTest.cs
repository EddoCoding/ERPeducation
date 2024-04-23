using ERPeducation.ViewModels.Modules.AdmissionCampaign.Old;
using System.Collections.ObjectModel;
using System.Windows;

namespace ERPeducation.Common.Windows.WindowTest
{
    public class DialogTest : IDialogTest
    {
        public void GetTest(ObservableCollection<TestViewModel> test)
        {
            TestView testView = new TestView();
            testView.DataContext = new TestViewModel(test, testView.Close);
            testView.ShowDialog();
        }
        public void GetTest(TestViewModel test)
        {
            MessageBox.Show(test.When.ToString(), test.Where);
            //TestView testView = new TestView();
            //testView.DataContext = new TestViewModel(test, testView.Close);
            //testView.ShowDialog();
        }
    }
}
