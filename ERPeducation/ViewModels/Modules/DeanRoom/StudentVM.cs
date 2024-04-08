using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.DeanRoom
{
    public class StudentVM
    {
        public ObservableCollection<TreeViewStudent> Students { get; set; }

        public StudentVM() 
        {
            Students = new ObservableCollection<TreeViewStudent>();
        }
    }
}
