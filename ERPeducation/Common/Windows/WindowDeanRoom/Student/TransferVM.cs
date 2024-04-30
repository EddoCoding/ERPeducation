using ERPeducation.Common.BD;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ERPeducation.ViewModels.Modules.DeanRoom;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using System.Windows;
using ERPeducation.ViewModels.Modules.DeanRoom.Old.Services;

namespace ERPeducation.Common.Windows.WindowDeanRoom.Student
{
    public class TransferVM : ReactiveObject
    {
        public TreeViewStudent Student { get; set; }

        public ICollection<TreeViewFaculty> Faculties { get; set; }
        TreeViewFaculty selectedFaculty;
        public TreeViewFaculty SelectedFaculty
        {
            get => selectedFaculty;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedFaculty, value);
                Departments.Clear();
                foreach(var departments in selectedFaculty.Items)
                    Departments.Add(departments);
            }
        }

        public ObservableCollection<TreeViewDepartment> Departments { get; set; }
        TreeViewDepartment selectedDepartment;
        public TreeViewDepartment SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedDepartment, value);
                Groups.Clear();
                if(selectedDepartment != null)
                    foreach (var groups in selectedDepartment.Items)
                        Groups.Add(groups);

            }
        }


        public ObservableCollection<TreeViewGroup> Groups { get; set; }
        TreeViewGroup selectedGroup;
        public TreeViewGroup SelectedGroup
        {
            get => selectedGroup;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedGroup, value);
            }
        }

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Unit,Unit> TransferCommand { get; set; }

        Action closeWindow;

        IEducationalService<TreeViewStudent> _educationalService;
        ObservableCollection<TreeViewMain> treeViewMain;
        public TransferVM(IEducationalService<TreeViewStudent> educationalService, TreeViewStudent student, Action closeWindow)
        {
            _educationalService = educationalService;
            Student = student;
            this.closeWindow = closeWindow;

            Faculties = new List<TreeViewFaculty>();
            Departments = new ObservableCollection<TreeViewDepartment>();
            Groups = new ObservableCollection<TreeViewGroup>();

            foreach (var main in treeViewMain)
                foreach (var faculties in main.Items)
                    Faculties.Add(faculties);

            CloseWindowCommand = ReactiveCommand.Create(Exit);
        }

        void Exit() => closeWindow();
    }
}
