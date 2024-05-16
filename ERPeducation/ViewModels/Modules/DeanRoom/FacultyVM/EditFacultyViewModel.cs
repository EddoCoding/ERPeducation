using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom.FacultyVM
{
    public class EditFacultyViewModel : ReactiveObject
    {
        public Faculty OldNameFaculty { get; set; }
        public Faculty NewNameFaculty { get; set; } = new Faculty();

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Faculty, Unit> EditFacultyCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public EditFacultyViewModel(IDeanRoomRepository repository, Faculty faculty, Action closeWindow)
        {
            _repository = repository;
            OldNameFaculty = faculty;
            _closeWindow = closeWindow;

            NewNameFaculty.NameFaculty = faculty.NameFaculty;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            EditFacultyCommand = ReactiveCommand.Create<Faculty>(EditFaculty);
        }

        void Exit() => _closeWindow();
        void EditFaculty(Faculty faculty)
        {
            if (NewNameFaculty.NameFaculty == OldNameFaculty.NameFaculty)
            {
                _closeWindow();
                return;
            }

            NewNameFaculty.Levels = faculty.Levels;
            EditNesting();

            _repository.EditFaculty(faculty, NewNameFaculty);
            _closeWindow();
        }

        void EditNesting()
        {
            if (NewNameFaculty.Levels != null)
                foreach (var level in NewNameFaculty.Levels)
                {
                    level.TitleFaculty = NewNameFaculty.NameFaculty;
                    if (level.Forms != null)
                        foreach (var form in level.Forms)
                        {
                            form.TitleFaculty = NewNameFaculty.NameFaculty;
                            if (form.TypeGroups != null)
                                foreach (var typeGroup in form.TypeGroups)
                                {
                                    typeGroup.TitleFaculty = NewNameFaculty.NameFaculty;
                                    if (typeGroup.Groups != null)
                                        foreach (var group in typeGroup.Groups)
                                        {
                                            group.TitleFaculty = NewNameFaculty.NameFaculty;
                                            if (group.Students != null)
                                                foreach (var student in group.Students)
                                                    student.TitleFaculty = NewNameFaculty.NameFaculty;
                                        }
                                }
                        }
                }
        }


    }
}
