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

        public FormsOfTraining SelectedForm {get; set;}
        public LvlOfTraining SelectedLevel { get; set; }
        public Faculty SelectedFaculty {get; set;}

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<TypeGroup, Unit> AddTypeGroupCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public AddTypeGroupViewModel(IDeanRoomRepository repository, FormsOfTraining selectedForm, LvlOfTraining selectedLevel, Faculty selectedFaculty, Action closeWindow)
        {
            _repository = repository;
            SelectedForm = selectedForm;
            SelectedLevel = selectedLevel;
            SelectedFaculty = selectedFaculty;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddTypeGroupCommand = ReactiveCommand.Create<TypeGroup>(AddTypeGroup);
        }

        void Exit() => _closeWindow();
        void AddTypeGroup(TypeGroup typeGroup)
        {
            typeGroup.TitleFaculty = SelectedFaculty.NameFaculty;
            typeGroup.TitleLevel = SelectedLevel.NameLevel;
            typeGroup.TitleForm = SelectedForm.NameForm;
            _repository.CreateTypeGroup(typeGroup, SelectedForm, SelectedLevel, SelectedFaculty);
            _closeWindow();
        }
    }
}