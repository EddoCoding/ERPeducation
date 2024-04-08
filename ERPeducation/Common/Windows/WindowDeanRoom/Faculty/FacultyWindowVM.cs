using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.Common.Windows.WindowDeanRoom.Faculty
{
    public class FacultyWindowVM : ReactiveObject
    {
        public string TextAddChange { get; set; }
        public string FacultyName { get; set; }

        TreeViewMain? treeViewMain;

        public ReactiveCommand<Unit, Unit> AddFacultyCommand { get; set; }
        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }

        Action closeWindow;

        public FacultyWindowVM(TreeViewMain treeViewMain, Action closeWindow) 
        {
            this.treeViewMain = treeViewMain;
            this.closeWindow = closeWindow;

            AddFacultyCommand = ReactiveCommand.Create(AddFaculty);
            CloseWindowCommand = ReactiveCommand.Create(Exit);
        }

        void AddFaculty()
        {
            treeViewMain.Items.Add(new TreeViewFaculty(FacultyName));
            closeWindow();
        }
        void Exit() => closeWindow();
    }
}