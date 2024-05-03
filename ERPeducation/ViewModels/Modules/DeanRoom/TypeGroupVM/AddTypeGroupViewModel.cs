using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.DeanRoom.TypeGroupVM
{
    public class AddTypeGroupViewModel : ReactiveObject
    {
        public TypeGroup TypeGroup { get; set; } = new();

        LvlOfTraining _selectedLevel;
        Faculty _selectedFaculty;
        FormsOfTraining _selectedForm;

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<TypeGroup, Unit> AddTypeGroupCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public AddTypeGroupViewModel(IDeanRoomRepository repository, FormsOfTraining selectedForm, LvlOfTraining selectedLevel, Faculty selectedFaculty, Action closeWindow)
        {
            _repository = repository;
            _selectedForm = selectedForm;
            _selectedLevel = selectedLevel;
            _selectedFaculty = selectedFaculty;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddTypeGroupCommand = ReactiveCommand.Create<TypeGroup>(AddTypeGroup);
        }

        void Exit() => _closeWindow();
        void AddTypeGroup(TypeGroup typeGroup)
        {
            _repository.CreateTypeGroup(typeGroup, _selectedForm, _selectedLevel, _selectedFaculty);
            _closeWindow();
        }
    }
}