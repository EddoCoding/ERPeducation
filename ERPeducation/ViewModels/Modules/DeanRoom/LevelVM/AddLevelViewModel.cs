using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.DeanRoom.LevelVM
{
    public class AddLevelViewModel : ReactiveObject
    {
        public LvlOfTraining Level { get; set; } = new();

        Faculty _selectedFaculty;

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<LvlOfTraining, Unit> AddLevelCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public AddLevelViewModel(IDeanRoomRepository repository, Faculty selectedFaculty, Action closeWindow)
        {
            _repository = repository;
            _selectedFaculty = selectedFaculty;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddLevelCommand = ReactiveCommand.Create<LvlOfTraining>(AddLevel);
        }

        void Exit() => _closeWindow();
        void AddLevel(LvlOfTraining level)
        {
            _repository.CreateLevel(level, _selectedFaculty);
            _closeWindow();
        }
    }
}
