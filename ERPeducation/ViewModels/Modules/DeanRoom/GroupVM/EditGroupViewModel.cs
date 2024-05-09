using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.DeanRoom.GroupVM
{
    public class EditGroupViewModel : ReactiveObject
    {
        public Group OldGroup { get; set; }
        public Group NewGroup { get; set; }

        public Faculty SelectedFaculty { get; set; }
        public LvlOfTraining SelectedLevel { get; set; }
        public FormsOfTraining SelectedForm { get; set; }
        public TypeGroup SelectedTypeGroup { get; set; }

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Group, Unit> EditGroupCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public EditGroupViewModel(IDeanRoomRepository repository, Group group, TypeGroup typeGroup, FormsOfTraining selectedForm, LvlOfTraining selectedLevel, Faculty selectedFaculty, Action closeWindow)
        {
            _repository = repository;
            OldGroup = group;
            SelectedForm = selectedForm;
            SelectedLevel = selectedLevel;
            SelectedFaculty = selectedFaculty;
            SelectedTypeGroup = typeGroup;
            _closeWindow = closeWindow;

            NewGroup = new Group();

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            EditGroupCommand = ReactiveCommand.Create<Group>(EditGroup);
        }

        void Exit() => _closeWindow();
        void EditGroup(Group group)
        {
            NewGroup.Students = group.Students;
            NewGroup.TitleFaculty = group.TitleFaculty;
            NewGroup.TitleLevel = group.TitleLevel;
            NewGroup.TitleForm = group.TitleForm;
            NewGroup.TitleTypeGroup = group.TitleTypeGroup;
            _repository.EditGroup(group, NewGroup, SelectedTypeGroup, SelectedForm, SelectedLevel, SelectedFaculty);
            _closeWindow();
        }
    }
}
