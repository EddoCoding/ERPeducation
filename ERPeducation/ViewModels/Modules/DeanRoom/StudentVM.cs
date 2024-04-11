using ERPeducation.Common.BD;
using ERPeducation.Common.Command;
using ERPeducation.Common.Windows.WindowDeanRoom.Student;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ERPeducation.ViewModels.Modules.DeanRoom.Services;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom
{
    public class StudentVM : ReactiveObject
    {
        public ObservableCollection<TreeViewStudent> Students { get; set; }

        TreeViewStudent selectedStudent;
        public TreeViewStudent SelectedStudent
        {
            get => selectedStudent;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedStudent, value);
                if (selectedStudent != null) InitializingStudents?.Invoke(this);
            }
        }

        ObservableCollection<TreeViewMain>? treeViewMain;

        TreeViewGroup? selectedGroup;

        public ReactiveCommand<Unit, Unit> CreateStudentCommand { get; set; }
        public ReactiveCommand<TreeViewStudent, Unit> ChangeStudentCommand { get; set; }
        public ReactiveCommand<TreeViewStudent, Unit> DeductStudentCommand { get; set; }

        IStudent _student;
        IEducationalService<TreeViewStudent> _educationalService;
        public StudentVM(IStudent student, IEducationalService<TreeViewStudent> educationalService, ObservableCollection<TreeViewMain>? treeViewMain) 
        {
            _student = student;
            _educationalService = educationalService;
            this.treeViewMain = treeViewMain;

            Students = new ObservableCollection<TreeViewStudent>();

            CreateStudentCommand = ReactiveCommand.Create(AddStudent);
            ChangeStudentCommand = ReactiveCommand.Create<TreeViewStudent>(student => ChangeStudent(student));
            DeductStudentCommand = ReactiveCommand.Create<TreeViewStudent>(student => DeductStudent(student));
        }

        public event Action<StudentVM> InitializingStudents;

        void AddStudent()
        {
            if (selectedGroup != null)
            {
                treeViewMain = _educationalService.jsonService.DeserializeTreeViewMain();

                foreach (var main in treeViewMain)
                    foreach (var faculties in main.Items)
                        foreach (var departments in faculties.Items)
                            foreach(var groups in departments.Items)
                                if (groups.Title == selectedGroup.Title)
                                {
                                    _student.AddStudent(groups);

                                    _educationalService.jsonService.CreateFacultyFileJson(FileServer.structPathFaculty, treeViewMain);

                                    GetEducationalData();

                                    return;
                                }

            }
        }
        void ChangeStudent(TreeViewStudent student) 
        {
            treeViewMain = _educationalService.jsonService.DeserializeTreeViewMain();

            foreach (var main in treeViewMain)
                foreach (var faculty in main.Items)
                    foreach (var departments in faculty.Items)
                        foreach (var groups in departments.Items)
                            foreach(var students in groups.Items)
                                if (students.FullName == student.FullName)
                                    _student.ChangeStudent(students);

            _educationalService.jsonService.CreateFacultyFileJson(FileServer.structPathFaculty, treeViewMain);

            GetEducationalData();
        }
        void DeductStudent(TreeViewStudent student)
        {
            treeViewMain = _educationalService.jsonService.DeserializeTreeViewMain();

            foreach (var main in treeViewMain)
                foreach (var faculty in main.Items)
                    foreach (var departments in faculty.Items)
                        foreach(var groups in departments.Items)
                            for (int i = groups.Items.Count - 1; i >= 0; i--)
                            {
                                var students = groups.Items[i];
                                if (students.FullName == student.FullName)
                                {
                                    groups.Items.RemoveAt(i);
                                    break;
                                }
                            }

            _educationalService.jsonService.CreateFacultyFileJson(FileServer.structPathFaculty, treeViewMain);

            GetEducationalData();
        }

        void GetEducationalData()
        {
            Students.Clear();

            foreach (var student in _educationalService.GetEducationalData(selectedGroup))
                Students.Add(student);
        }
        public void SetSelectedGroup(TreeViewGroup treeViewGroup) => selectedGroup = treeViewGroup;
    }
}