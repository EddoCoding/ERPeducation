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

        public Faculty SelectedFaculty {get; set;}
        public LvlOfTraining SelectedLevel {get; set;}
        public FormsOfTraining SelectedForm {get; set;}
        public TypeGroup SelectedTypeGroup { get; set; }

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Group, Unit> AddGroupCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public AddGroupViewModel(IDeanRoomRepository repository, TypeGroup typeGroup, FormsOfTraining selectedForm, LvlOfTraining selectedLevel, Faculty selectedFaculty, Action closeWindow)
        {
            _repository = repository;
            SelectedForm = selectedForm;
            SelectedLevel = selectedLevel;
            SelectedFaculty = selectedFaculty;
            SelectedTypeGroup = typeGroup;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddGroupCommand = ReactiveCommand.Create<Group>(AddGroup);
        }

        void Exit() => _closeWindow();
        void AddGroup(Group group)
        {
            group.TitleFaculty = SelectedFaculty.NameFaculty;
            group.TitleLevel = SelectedLevel.NameLevel;
            group.TitleForm = SelectedForm.NameForm;
            group.TitleTypeGroup = SelectedTypeGroup.NameType;
            _repository.CreateGroup(group, SelectedTypeGroup, SelectedForm, SelectedLevel, SelectedFaculty);
            _closeWindow();
        }
    }
}