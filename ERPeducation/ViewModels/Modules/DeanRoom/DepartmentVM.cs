using ERPeducation.Common.BD;
using ERPeducation.Common.Command;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ERPeducation.ViewModels.Modules.DeanRoom.Services;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.DeanRoom
{
    public class DepartmentVM : ReactiveObject
    {
        public ObservableCollection<TreeViewDepartment> Departments { get; set; }

        TreeViewDepartment selectedDepartment = new TreeViewDepartment("Выберете кафедру");
        public TreeViewDepartment SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedDepartment, value);
                if (selectedDepartment != null)
                {
                    InitializingGroups?.Invoke(this);
                }
            }
        }

        ObservableCollection<TreeViewMain>? treeViewMain;

        TreeViewFaculty? selectedFaculty;

        public ReactiveCommand<Unit, Unit> CreateGroupCommand { get; set; }
        public ReactiveCommand<TreeViewGroup, Unit> LiquidationGroupCommand { get; set; }
        public ReactiveCommand<TreeViewGroup, Unit> ChangeGroupCommand { get; set; }
        public ReactiveCommand<TreeViewGroup, Unit> InfoGroupCommand { get; set; }

        IEducationalService _educationalService;
        public DepartmentVM(IEducationalService educationalService, ObservableCollection<TreeViewMain>? treeViewMain)
        {
            _educationalService = educationalService;
            this.treeViewMain = treeViewMain;

            Departments = new ObservableCollection<TreeViewDepartment>();

            CreateGroupCommand = ReactiveCommand.Create(AddDepartment);
            LiquidationGroupCommand = ReactiveCommand.Create<TreeViewGroup>(group => { MessageBox.Show("Ликвидировать"); });
            ChangeGroupCommand = ReactiveCommand.Create<TreeViewGroup>(group => { MessageBox.Show("Изменить"); });
            InfoGroupCommand = ReactiveCommand.Create<TreeViewGroup>(group => { MessageBox.Show("Информация"); });
        }

        public event Action<DepartmentVM> InitializingGroups;

        void AddDepartment()
        {
            MessageBox.Show(selectedFaculty.Title);

            //treeViewMain = _educationalService.jsonService.DeserializeTreeViewMain();
            //
            //foreach (var main in treeViewMain)
            //{
            //    foreach (var faculties in main.Items)
            //    {
            //        
            //    }
            //    //main.Items.Add(new TreeViewFaculty($"Факультет"));
            //    //_educationalService.jsonService.CreateFacultyFileJson(FileServer.structPathFaculty, treeViewMain);
            //
            //    //GetEducationalData();
            //}
        }

        public void SetSelectedFaculty(TreeViewFaculty treeViewFaculty) => selectedFaculty = treeViewFaculty;
    }
}
