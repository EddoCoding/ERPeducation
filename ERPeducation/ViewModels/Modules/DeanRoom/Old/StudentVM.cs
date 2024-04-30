using ERPeducation.Common.Windows.WindowAddStudentFromEnrollees;
using ERPeducation.Common.Windows.WindowDeanRoom.Student;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ERPeducation.ViewModels.Modules.DeanRoom.Old.Services;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Old
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
        public ReactiveCommand<Unit, Unit> CreateStudentFromEnrolleesCommand { get; set; }
        public ReactiveCommand<TreeViewStudent, Unit> ChangeStudentCommand { get; set; }
        public ReactiveCommand<TreeViewStudent, Unit> TransferStudentCommand { get; set; }
        public ReactiveCommand<TreeViewStudent, Unit> DeductStudentCommand { get; set; }

        IStudent _student;
        IEducationalService<TreeViewStudent> _educationalService;
        public StudentVM(IStudent student, IEducationalService<TreeViewStudent> educationalService, ObservableCollection<TreeViewMain>? treeViewMain)
        {
            _student = student;
            _educationalService = educationalService;
            this.treeViewMain = treeViewMain;

            Students = new ObservableCollection<TreeViewStudent>();

            CreateStudentFromEnrolleesCommand = ReactiveCommand.Create(AddStudentFromEnrollees);
        }

        public event Action<StudentVM> InitializingStudents;

        void AddStudentFromEnrollees() //Потом все вынести в сервис - тело метода
        {

            AddStudentFromEnrolleesWindow view = new();
            view.DataContext = new AddStudentFromEnrolleesViewModel(view.Close);
            view.ShowDialog();
        }

        TreeViewFaculty _faculty = new TreeViewFaculty("");
        TreeViewDepartment _department = new TreeViewDepartment("");
        TreeViewGroup _group = new TreeViewGroup("");
        public void SetSelectedGroup(TreeViewGroup treeViewGroup) => selectedGroup = treeViewGroup;
    }
}