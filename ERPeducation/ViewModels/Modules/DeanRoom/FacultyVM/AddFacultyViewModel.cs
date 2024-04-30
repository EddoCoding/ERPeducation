using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System;
using System.Reactive;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.DeanRoom.FacultyVM
{
    public class AddFacultyViewModel
    {
        public Faculty Faculty { get; set; } = new();

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Faculty, Unit> AddFacultyCommand { get; set; }

        Action closeWindow;

        IDeanRoomRepository _repository;
        public AddFacultyViewModel(IDeanRoomRepository deanRoomRepository, Action closeWindow)
        {
            _repository = deanRoomRepository;
            this.closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddFacultyCommand = ReactiveCommand.Create<Faculty>(AddFaculty);
        }

        void Exit() => closeWindow();
        void AddFaculty(Faculty faculty)
        {
            _repository.CreateFaculty(faculty);
            closeWindow();
        }
    }
}