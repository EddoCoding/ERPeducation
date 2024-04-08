using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.DeanRoom
{
    public class GroupVM : ReactiveObject
    {
        public ObservableCollection<TreeViewGroup> Groups { get; set; }

        TreeViewGroup selectedStudent = new TreeViewGroup("Выберите группу");
        public TreeViewGroup SelectedStudent
        {
            get => selectedStudent;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedStudent, value);
                InitializingStudents?.Invoke(this);
            }
        }


        public GroupVM()
        {
            Groups = new ObservableCollection<TreeViewGroup>();
        }

        public event Action<GroupVM> InitializingStudents;
    }
}
