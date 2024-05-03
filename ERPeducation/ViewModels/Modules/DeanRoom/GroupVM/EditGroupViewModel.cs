using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.DeanRoom.GroupVM
{
    public class EditGroupViewModel : ReactiveObject
    {
        public Group OldNameGroup { get; set; }
        public Group NewNameGroup { get; set; }

        Faculty _selectedFaculty;
        LvlOfTraining _selectedLevel;
        FormsOfTraining _selectedForm;
        TypeGroup _selectedTypeGroup;

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Group, Unit> EditGroupCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public EditGroupViewModel(IDeanRoomRepository repository, Group group, TypeGroup typeGroup, FormsOfTraining selectedForm, LvlOfTraining selectedLevel, Faculty selectedFaculty, Action closeWindow)
        {
            _repository = repository;
            OldNameGroup = group;
            _selectedForm = selectedForm;
            _selectedLevel = selectedLevel;
            _selectedFaculty = selectedFaculty;
            _selectedTypeGroup = typeGroup;
            _closeWindow = closeWindow;

            NewNameGroup = new Group();

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            EditGroupCommand = ReactiveCommand.Create<Group>(EditGroup);
        }

        void Exit() => _closeWindow();
        void EditGroup(Group group)
        {
            NewNameGroup.Students = group.Students;
            _repository.EditGroup(group, NewNameGroup, _selectedTypeGroup, _selectedForm, _selectedLevel, _selectedFaculty);
            _closeWindow();
        }
    }
}
