using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ERPeducation.ViewModels.Modules.DeanRoom.Services;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Windows;

namespace ERPeducation.Common.Windows.WindowDeanRoom.Student
{
    public class Student : IStudent
    {
        public void AddStudent(TreeViewGroup treeViewGroup)
        {
            StudentView view = new StudentView();
            view.DataContext = new StudentWindowVM(treeViewGroup, view.Close) { TextAddChange = "Добавить" };
            view.ShowDialog();
        }

        public void ChangeStudent(TreeViewStudent student)
        {
            StudentView view = new StudentView();
            var vm = new StudentWindowVM()
            {
                SurName = student.SurName,
                Name = student.Name,
                MiddleName = student.MiddleName,
                DateOfBirth = student.DateOfBirth,
                Group = student.Group,
                Course = student.Course,
                Speciality = student.Speciality,
                LevelOfTraining = student.LevelOfTraining,
                FormOfStudy = student.FormOfStudy,

                CloseWindowCommand = ReactiveCommand.Create(view.Close),
                TextAddChange = "Изменить"
            };
            vm.AddStudentCommand = ReactiveCommand.Create(() =>
            {
                student.Title = $"{student.SurName} {student.Name} {student.MiddleName}";
                student.SurName = vm.SurName;
                student.Name = vm.Name;
                student.MiddleName = vm.MiddleName;
                student.FullName = $"{student.SurName} {student.Name} {student.MiddleName}";
                student.DateOfBirth = vm.DateOfBirth;
                student.Group = vm.Group;
                student.Course = vm.Course;
                student.Speciality = vm.Speciality;
                student.LevelOfTraining = vm.LevelOfTraining;
                student.FormOfStudy = vm.FormOfStudy;
            
                view.Close();
            });
            view.DataContext = vm;
            view.ShowDialog();
        }

        public void TransferStudent(IEducationalService<TreeViewStudent> educationalService, TreeViewStudent student)
        {
            TransferStudentView view = new TransferStudentView();
            view.DataContext = new TransferVM(educationalService, student, view.Close);
            view.ShowDialog();
        }
    }
}