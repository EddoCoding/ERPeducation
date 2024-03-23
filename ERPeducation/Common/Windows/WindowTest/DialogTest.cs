using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Windows.WindowTest
{
    public class DialogTest : IDialogTest
    {
        public void GetTest(ObservableCollection<TestViewModel> test)
        {
            TestView testView = new TestView();
            testView.DataContext = new TestViewModel(new DialogTest(), test, testView.Close);
            testView.ShowDialog();
        }
        public void GetTest(TestViewModel test)
        {
            TestView testView = new TestView();
            testView.DataContext = new TestViewModel(test, testView.Close);
            testView.ShowDialog();
        }
    }
}
