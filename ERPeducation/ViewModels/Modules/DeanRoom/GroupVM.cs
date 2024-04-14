using ERPeducation.Common.BD;
using ERPeducation.Common.Command;
using ERPeducation.Common.Windows.WindowDeanRoom.Group;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ERPeducation.ViewModels.Modules.DeanRoom.Services;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom
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
                if(selectedGroup != null) InitializingGroups?.Invoke(this);
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

            CreateGroupCommand = ReactiveCommand.Create(AddGroup);
            ChangeGroupCommand = ReactiveCommand.Create<TreeViewGroup>(group => ChangeGroup(group));
            ShowSyllabusCommand = ReactiveCommand.Create<TreeViewGroup>(group => SyllabusShow(group));
            LiquidationGroupCommand = ReactiveCommand.Create<TreeViewGroup>(group => LiquidationGroup(group));
        }

        public event Action<GroupVM> InitializingGroups;

        void AddGroup()
        {
            if(selectedDepartment != null)
            {
                treeViewMain = _educationalService.jsonService.DeserializeTreeViewMain();

                foreach (var main in treeViewMain)
                    foreach (var faculties in main.Items)
                        foreach(var departments in faculties.Items)
                            if(departments.Title == selectedDepartment.Title)
                            {
                                _group.AddGroup(departments);

                                _educationalService.jsonService.CreateFacultyFileJson(FileServer.structPathFaculty, treeViewMain);

                                GetEducationalData();

                                return;
                            }
            }
        }
        void ChangeGroup(TreeViewGroup group)
        {
            treeViewMain = _educationalService.jsonService.DeserializeTreeViewMain();

            foreach (var main in treeViewMain)
                foreach (var faculty in main.Items)
                    foreach (var departments in faculty.Items)
                        foreach(var groups in departments.Items)
                            if(groups.GroupNumber == group.GroupNumber)
                                _group.ChangeGroup(groups);

            _educationalService.jsonService.CreateFacultyFileJson(FileServer.structPathFaculty, treeViewMain);

            GetEducationalData();
        }
        void SyllabusShow(TreeViewGroup group) => NotReady.Message();
        void LiquidationGroup(TreeViewGroup group)
        {
            treeViewMain = _educationalService.jsonService.DeserializeTreeViewMain();

            foreach (var main in treeViewMain)
                foreach (var faculty in main.Items)
                    foreach(var departments in faculty.Items)
                        for (int i = departments.Items.Count - 1; i >= 0; i--)
                        {
                            var groups = departments.Items[i];
                            if (groups.GroupNumber == group.GroupNumber)
                            {
                                departments.Items.RemoveAt(i);
                                break;
                            }
                        }

            _educationalService.jsonService.CreateFacultyFileJson(FileServer.structPathFaculty, treeViewMain);

            GetEducationalData();
        }

        void GetEducationalData()
        {
            Groups.Clear();

            foreach (var group in _educationalService.GetEducationalData(selectedDepartment))
                Groups.Add(group);
        }
        public void SetSelectedDepartment(TreeViewDepartment treeViewDepartment) => selectedDepartment = treeViewDepartment;
    }
}