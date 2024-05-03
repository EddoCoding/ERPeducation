using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom.FacultyVM
{
    public class AddFacultyViewModel : ReactiveObject
    {
        public Faculty Faculty { get; set; } = new();

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Faculty, Unit> AddFacultyCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public AddFacultyViewModel(IDeanRoomRepository deanRoomRepository, Action closeWindow)
        {
            _repository = deanRoomRepository;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddFacultyCommand = ReactiveCommand.Create<Faculty>(AddFaculty);
        }

        void Exit() => _closeWindow();
        void AddFaculty(Faculty faculty)
        {
            _repository.CreateFaculty(faculty);
            _closeWindow();
        }
    }
}