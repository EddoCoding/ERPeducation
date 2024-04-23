using ERPeducation.ViewModels.Modules.AdmissionCampaign.Old;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Windows.WindowTest
{
    public interface IDialogTest
    {
        void GetTest(ObservableCollection<TestViewModel> test);
        void GetTest(TestViewModel test);
    }
}
