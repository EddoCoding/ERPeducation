using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ReactiveUI;

namespace ERPeducation.Common.Windows.WindowDeanRoom.Group
{
    public class Group : IGroup
    {
        public void AddGroup(TreeViewDepartment treeViewDepartment)
        {
            GroupView view = new GroupView();
            view.DataContext = new GroupWindowVM(treeViewDepartment, view.Close) { TextAddChange = "Добавить" };
            view.ShowDialog();
        }

        public void ChangeGroup(TreeViewGroup group)
        {
            GroupView view = new GroupView();
            var vm = new GroupWindowVM()
            {
                GroupNumber = group.GroupNumber,
                Speciality = group.Speciality,
                LvlOfStudy = group.LvlOfStudy,
                FormOfStudy = group.FormOfStudy,
                Course = group.Course,
                StartDateOfTraining = group.StartDateOfTraining,
                EndDateOfTraining = group.EndDateOfTraining,
                Curator = group.Curator,
                Headman = group.Headman,

                CloseWindowCommand = ReactiveCommand.Create(view.Close),
                TextAddChange = "Изменить"
            };
            vm.AddGroupCommand = ReactiveCommand.Create(() =>
            {
                group.GroupNumber = vm.GroupNumber;
                group.Speciality = vm.Speciality;
                group.LvlOfStudy = vm.LvlOfStudy;
                group.FormOfStudy = vm.FormOfStudy;
                group.Course = vm.Course;
                group.StartDateOfTraining = vm.StartDateOfTraining;
                group.EndDateOfTraining = vm.EndDateOfTraining;
                group.Curator = vm.Curator;
                group.Headman = vm.Headman;

                view.Close();
            });
            view.DataContext = vm;
            view.ShowDialog();
        }
    }
}
