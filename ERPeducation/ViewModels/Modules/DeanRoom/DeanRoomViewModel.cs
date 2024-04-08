using ERPeducation.Common.Windows.WindowDeanRoom;
using ERPeducation.Common.Windows.WindowDeanRoom.Faculty;
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
            DepartmentVM = new DepartmentVM(new DepartmentService(), treeViewMain);
            GroupVM = new GroupVM();
            StudentVM = new StudentVM();

            FacultyVM.InitializingDepartments += faculty => GetDepartments(faculty);
            DepartmentVM.InitializingGroups += department => GetGroups(department);
            GroupVM.InitializingStudents += student => GetStudents(student);
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

            GroupVM.Groups.Add(new TreeViewGroup("Группа 1"));
        }

        void GetStudents(GroupVM group)
        {
            StudentVM.Students.Clear();
            foreach (var student in group.SelectedStudent.Items)
                StudentVM.Students.Add(student);

            StudentVM.Students.Add(new TreeViewStudent("Студент 1"));
        }
    }
}
