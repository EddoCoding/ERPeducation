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
            NewNameFaculty.Levels = faculty.Levels;
            _repository.EditFaculty(faculty, NewNameFaculty);
            _closeWindow();
        }
    }
}
