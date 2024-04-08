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
            FacultyVM = new FacultyVM(new FacultyService(), treeViewMain); //Переименовать фэкульти в эдукейшионал
            DepartmentVM = new DepartmentVM(new FacultyService(), treeViewMain); //Переименовать фэкульти в эдукейшионал
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


        //void GetDepartments(string department)
        //{
        //    Departments.Clear();
        //    foreach(var itemOne in treeViewMain)
        //    {
        //        foreach(var itemTwo in itemOne.Items)
        //        {
        //            if(itemTwo.Title == department) foreach (var itemThree in itemTwo.Items) Departments.Add(itemThree.Title);
        //        }
        //    }
        //}

        //void GetGroup(string group)
        //{
        //    Groups.Clear();
        //    foreach (var itemOne in treeViewMain)
        //    {
        //        foreach (var itemTwo in itemOne.Items)
        //        {
        //            foreach (var itemThree in itemTwo.Items)
        //            {
        //                if (itemThree.Title == group) foreach (var itemFour in itemThree.Items) Groups.Add(itemFour.Title);
        //            }
        //        }
        //    }
        //}

        //void GetStudent(string student)
        //{
        //    Students.Clear();
        //    foreach (var itemOne in treeViewMain)
        //    {
        //        foreach (var itemTwo in itemOne.Items)
        //        {
        //            foreach (var itemThree in itemTwo.Items)
        //            {
        //                foreach (var itemFour in itemThree.Items)
        //                {
        //                    if(itemFour.Title == student) foreach(var jopa in itemFour.Items) Students.Add(jopa.Title);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
