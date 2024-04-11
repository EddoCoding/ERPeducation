using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.Common.Windows.WindowDeanRoom.Student
{
    public class StudentWindowVM
    {
        public string TextAddChange { get; set; } = string.Empty;

        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Group {  get; set; } = string.Empty;
        public int Course { get; set; }
        public string Speciality { get; set; } = string.Empty;
        public string LevelOfTraining { get; set; } = string.Empty;
        public string FormOfStudy { get; set; } = string.Empty;
        //public ObservableCollection<PersonalDocumentBase> PersonalDocuments { get; set; } = new(); //Персональные документы
        //public ObservableCollection<EducationDocumentBase> EducationDocuments { get; set; } = new(); //Образование документы
        //public AcademicPerformance AcademicPerfomance { get; set; } = new(); //Класс успеваемости - разработать
        //public Finance Finance { get; set; } = new(); //Класс финансов - разработать

        TreeViewGroup? treeViewGroup;

        public ReactiveCommand<Unit, Unit> AddStudentCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }

        Action closeWindow;

        public StudentWindowVM() { }
        public StudentWindowVM(TreeViewGroup treeViewGroup, Action closeWindow)
        {
            this.treeViewGroup = treeViewGroup;
            this.closeWindow = closeWindow;

            AddStudentCommand = ReactiveCommand.Create(AddGroup);
            CloseWindowCommand = ReactiveCommand.Create(Exit);
        }

        void AddGroup()
        {
            treeViewGroup.Items.Add(new TreeViewStudent(SurName, Name, MiddleName)
            {
                DateOfBirth = DateOfBirth,
                Group = Group,
                Course = Course,
                Speciality = Speciality,
                LevelOfTraining = LevelOfTraining,
                FormOfStudy = FormOfStudy
            });
            closeWindow();
        }
        void Exit() => closeWindow();
    }
}
