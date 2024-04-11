using ERPeducation.Common.Windows.WindowDeanRoom.Department;
using ERPeducation.Common.Windows.WindowDeanRoom.Faculty;
using ERPeducation.Common.Windows.WindowDeanRoom.Group;
using ERPeducation.Common.Windows.WindowDeanRoom.Student;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ERPeducation.ViewModels.Modules.DeanRoom.Services;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.DeanRoom
{
    public class DeanRoomViewModel : ReactiveObject
    {
        public FacultyVM FacultyVM { get; set; }
        public DepartmentVM DepartmentVM { get; set; }
        public GroupVM GroupVM { get; set; }
        public StudentVM StudentVM { get; set; }

        public DeanRoomViewModel(ObservableCollection<TreeViewMain>? treeViewMain = default)
        {
            FacultyVM = new FacultyVM(new Faculty(), new FacultyService(), treeViewMain);
            DepartmentVM = new DepartmentVM(new Department(), new DepartmentService(), treeViewMain);
            GroupVM = new GroupVM(new Group(), new GroupService(), treeViewMain);
            StudentVM = new StudentVM(new Student(), new StudentService(), treeViewMain);

            FacultyVM.InitializingDepartments += faculty => GetDepartments(faculty);
            DepartmentVM.InitializingGroups += department => GetGroups(department);
            GroupVM.InitializingGroups += student => GetStudents(student);
        }

        void GetDepartments(FacultyVM faculty)
        {
            DepartmentVM.Departments.Clear();
            foreach(var department in faculty.SelectedFaculty.Items)
                DepartmentVM.Departments.Add(department);
            DepartmentVM.SetSelectedFaculty(FacultyVM.SelectedFaculty);
        }
        void GetGroups(DepartmentVM department)
        {
            GroupVM.Groups.Clear();
            foreach (var group in department.SelectedDepartment.Items)
                GroupVM.Groups.Add(group);
            GroupVM.SetSelectedDepartment(DepartmentVM.SelectedDepartment);
        }
        void GetStudents(GroupVM group)
        {
            StudentVM.Students.Clear();
            foreach (var student in group.SelectedGroup.Items)
                StudentVM.Students.Add(student);
            StudentVM.SetSelectedGroup(GroupVM.SelectedGroup);
        }
    }
}
