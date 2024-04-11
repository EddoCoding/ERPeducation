using DynamicData;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.Common.Windows.WindowDeanRoom.Group
{
    public class GroupWindowVM
    {
        public string TextAddChange { get; set; } = string.Empty;

        public string GroupNumber { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
        public string LvlOfStudy { get; set; } = string.Empty;
        public string FormOfStudy { get; set; } = string.Empty;
        public int Course { get; set; }
        public DateTime StartDateOfTraining { get; set; }
        public DateTime EndDateOfTraining { get; set; }
        public string Curator { get; set; } = string.Empty;
        public string Headman { get; set; } = string.Empty;


        TreeViewDepartment? treeViewDepartment;

        public ReactiveCommand<Unit, Unit> AddGroupCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }

        Action closeWindow;

        public GroupWindowVM() { }
        public GroupWindowVM(TreeViewDepartment treeViewDepartment, Action closeWindow)
        {
            this.treeViewDepartment = treeViewDepartment;
            this.closeWindow = closeWindow;

            AddGroupCommand = ReactiveCommand.Create(AddGroup);
            CloseWindowCommand = ReactiveCommand.Create(Exit);
        }

        void AddGroup()
        {
            treeViewDepartment.Items.Add(new TreeViewGroup(GroupNumber)
            {
                Speciality = Speciality,
                LvlOfStudy = LvlOfStudy,
                FormOfStudy = FormOfStudy,
                Course = Course,
                StartDateOfTraining = StartDateOfTraining,
                EndDateOfTraining = EndDateOfTraining,
                Curator = Curator,
                Headman = Headman
            });
            closeWindow();
        }
        void Exit() => closeWindow();
    }
}
