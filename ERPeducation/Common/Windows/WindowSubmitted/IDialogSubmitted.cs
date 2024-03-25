using ERPeducation.Common.Interface;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Windows.WindowSubmitted
{
    public interface IDialogSubmitted
    {
        void GetSubmitted(ObservableCollection<ISubmitted> submitted);
    }
}
