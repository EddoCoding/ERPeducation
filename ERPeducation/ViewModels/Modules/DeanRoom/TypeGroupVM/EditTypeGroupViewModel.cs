using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.DeanRoom.TypeGroupVM
{
    public class EditTypeGroupViewModel : ReactiveObject
    {
        public TypeGroup OldNameTypeGroup { get; set; }
        public TypeGroup NewNameTypeGroup { get; set; }

        public FormsOfTraining SelectedForm { get; set; }
        public LvlOfTraining SelectedLevel { get; set; }
        public Faculty SelectedFaculty { get; set; }

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<TypeGroup, Unit> EditTypeGroupCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public EditTypeGroupViewModel(IDeanRoomRepository repository, TypeGroup typeGrup, FormsOfTraining form, LvlOfTraining level, Faculty faculty, Action closeWindow)
        {
            _repository = repository;
            OldNameTypeGroup = typeGrup;
            SelectedForm = form;
            SelectedLevel = level;
            SelectedFaculty = faculty;
            _closeWindow = closeWindow;

            NewNameTypeGroup = new TypeGroup();

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            EditTypeGroupCommand = ReactiveCommand.Create<TypeGroup>(EditTypeGroup);
        }

        void Exit() => _closeWindow();
        void EditTypeGroup(TypeGroup typeGroup)
        {
            NewNameTypeGroup.Groups = typeGroup.Groups;
            NewNameTypeGroup.TitleFaculty = typeGroup.TitleFaculty;
            NewNameTypeGroup.TitleLevel = typeGroup.TitleLevel;
            NewNameTypeGroup.TitleForm = typeGroup.TitleForm;
            _repository.EditTypeGroup(typeGroup, NewNameTypeGroup, SelectedForm, SelectedLevel, SelectedFaculty);
            _closeWindow();
        }
    }
}