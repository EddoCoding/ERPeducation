using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.DeanRoom.GroupVM
{
    public class AddGroupViewModel : ReactiveObject
    {
        public Group Group { get; set; } = new();

        Faculty _selectedFaculty;
        LvlOfTraining _selectedLevel;
        FormsOfTraining _selectedForm;
        TypeGroup _selectedTypeGroup;

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Group, Unit> AddGroupCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public AddGroupViewModel(IDeanRoomRepository repository, TypeGroup typeGroup, FormsOfTraining selectedForm, LvlOfTraining selectedLevel, Faculty selectedFaculty, Action closeWindow)
        {
            _repository = repository;
            _selectedForm = selectedForm;
            _selectedLevel = selectedLevel;
            _selectedFaculty = selectedFaculty;
            _selectedTypeGroup = typeGroup;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddGroupCommand = ReactiveCommand.Create<Group>(AddGroup);
        }

        void Exit() => _closeWindow();
        void AddGroup(Group group)
        {
            _repository.CreateGroup(group, _selectedTypeGroup, _selectedForm, _selectedLevel, _selectedFaculty);
            _closeWindow();
        }
    }
}