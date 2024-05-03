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

        LvlOfTraining _selectedLevel;
        Faculty _selectedFaculty;
        FormsOfTraining _selectedForm;

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<TypeGroup, Unit> EditTypeGroupCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public EditTypeGroupViewModel(IDeanRoomRepository repository, TypeGroup typeGrup, FormsOfTraining form, LvlOfTraining level, Faculty faculty, Action closeWindow)
        {
            _repository = repository;
            OldNameTypeGroup = typeGrup;
            _selectedForm = form;
            _selectedLevel = level;
            _selectedFaculty = faculty;
            _closeWindow = closeWindow;

            NewNameTypeGroup = new TypeGroup();

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            EditTypeGroupCommand = ReactiveCommand.Create<TypeGroup>(EditTypeGroup);
        }

        void Exit() => _closeWindow();
        void EditTypeGroup(TypeGroup typeGroup)
        {
            NewNameTypeGroup.Groups = typeGroup.Groups;
            _repository.EditTypeGroup(typeGroup, NewNameTypeGroup, _selectedForm, _selectedLevel, _selectedFaculty);
            _closeWindow();
        }
    }
}