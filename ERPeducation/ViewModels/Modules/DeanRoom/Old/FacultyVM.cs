using ERPeducation.Common.BD;
using ERPeducation.Common.Windows.WindowDeanRoom.Faculty;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ERPeducation.ViewModels.Modules.DeanRoom.Old.Services;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Old
{
    public class FacultyVM : ReactiveObject
    {
        public ObservableCollection<TreeViewFaculty> Faculties { get; set; }

        TreeViewFaculty selectedFaculty = new TreeViewFaculty("Выберете факультет");
        public TreeViewFaculty SelectedFaculty
        {
            get => selectedFaculty;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedFaculty, value);
                if (selectedFaculty != null) InitializingDepartments?.Invoke(this);
            }
        }

        ObservableCollection<TreeViewMain>? treeViewMain;

        public ReactiveCommand<Unit, Unit> AddFacultyCommand { get; set; }
        public ReactiveCommand<TreeViewFaculty, Unit> ChangeFacultyCommand { get; set; }
        public ReactiveCommand<TreeViewFaculty, Unit> DeleteFacultyCommand { get; set; }

        IFaculty _faculty;
        IEducationalService<TreeViewFaculty> _educationalService;
        public FacultyVM(IFaculty faculty, IEducationalService<TreeViewFaculty> educationalService, ObservableCollection<TreeViewMain>? treeViewMain)
        {
            _faculty = faculty;
            _educationalService = educationalService;
            this.treeViewMain = treeViewMain;

            Faculties = new ObservableCollection<TreeViewFaculty>();

            GetEducationalData();

            AddFacultyCommand = ReactiveCommand.Create(AddFaculty);

            ChangeFacultyCommand = ReactiveCommand.Create<TreeViewFaculty>(faculty => ChangeFaculty(faculty));
            DeleteFacultyCommand = ReactiveCommand.Create<TreeViewFaculty>(faculty => DelFaculty(faculty));
        }

        public event Action<FacultyVM>? InitializingDepartments;

        void AddFaculty()
        {
            treeViewMain = _educationalService.jsonService.DeserializeTreeViewMain();

            foreach (var main in treeViewMain)
            {
                _faculty.AddFaculty(main);

                _educationalService.jsonService.CreateFacultyFileJson(FileServer.structPathFaculty, treeViewMain);

                GetEducationalData();
            }
        }
        void ChangeFaculty(TreeViewFaculty faculty)
        {
            treeViewMain = _educationalService.jsonService.DeserializeTreeViewMain();

            foreach (var main in treeViewMain)
                foreach (var facultys in main.Items)
                    if (facultys.Title == faculty.Title)
                        _faculty.ChangeFaculty(facultys);

            _educationalService.jsonService.CreateFacultyFileJson(FileServer.structPathFaculty, treeViewMain);

            GetEducationalData();
        }
        void DelFaculty(TreeViewFaculty faculty)
        {
            treeViewMain = _educationalService.jsonService.DeserializeTreeViewMain();

            foreach (var main in treeViewMain)
            {
                for (int i = main.Items.Count - 1; i >= 0; i--)
                {
                    var item = main.Items[i];
                    if (item.Title == faculty.Title)
                    {
                        main.Items.RemoveAt(i);
                        break;
                    }
                }

                _educationalService.jsonService.CreateFacultyFileJson(FileServer.structPathFaculty, treeViewMain);

                GetEducationalData();
            }
        }
        void GetEducationalData()
        {
            Faculties.Clear();

            foreach (var faculty in _educationalService.GetEducationalData())
                Faculties.Add(faculty);
        }
    }
}