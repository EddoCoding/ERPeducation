using ERPeducation.Common.Windows.WindowDeanRoom.Group;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ERPeducation.ViewModels.Modules.DeanRoom.Old.Services;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Old
{
    public class GroupVM : ReactiveObject
    {
        public ObservableCollection<TreeViewGroup> Groups { get; set; }

        TreeViewGroup selectedGroup;
        public TreeViewGroup SelectedGroup
        {
            get => selectedGroup;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedGroup, value);
                if (selectedGroup != null) InitializingGroups?.Invoke(this);
            }
        }

        ObservableCollection<TreeViewMain>? treeViewMain;

        TreeViewDepartment? selectedDepartment;

        public ReactiveCommand<Unit, Unit> CreateGroupCommand { get; set; }
        public ReactiveCommand<TreeViewGroup, Unit> ChangeGroupCommand { get; set; }
        public ReactiveCommand<TreeViewGroup, Unit> ShowSyllabusCommand { get; set; }
        public ReactiveCommand<TreeViewGroup, Unit> LiquidationGroupCommand { get; set; }

        IGroup _group;
        IEducationalService<TreeViewGroup> _educationalService;
        public GroupVM(IGroup group, IEducationalService<TreeViewGroup> educationalService, ObservableCollection<TreeViewMain>? treeViewMain)
        {
            _group = group;
            _educationalService = educationalService;
            this.treeViewMain = treeViewMain;

            Groups = new ObservableCollection<TreeViewGroup>();
            ShowSyllabusCommand = ReactiveCommand.Create<TreeViewGroup>(group => SyllabusShow(group));
        }

        public event Action<GroupVM> InitializingGroups;

        void SyllabusShow(TreeViewGroup group) => NotReady.Message();
        
        void GetEducationalData()
        {
            Groups.Clear();

        }
        public void SetSelectedDepartment(TreeViewDepartment treeViewDepartment) => selectedDepartment = treeViewDepartment;
    }
}