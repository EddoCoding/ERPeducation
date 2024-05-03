using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom.FormVM
{
    public class AddFormViewModel : ReactiveObject
    {
        public FormsOfTraining Form { get; set; } = new();

        LvlOfTraining _selectedLevel;
        Faculty _selectedFaculty;

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<FormsOfTraining, Unit> AddFormCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public AddFormViewModel(IDeanRoomRepository repository, LvlOfTraining selectedLevel, Faculty selectedFaculty, Action closeWindow)
        {
            _repository = repository;
            _selectedLevel = selectedLevel;
            _selectedFaculty = selectedFaculty;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddFormCommand = ReactiveCommand.Create<FormsOfTraining>(AddForm);
        }

        void Exit() => _closeWindow();
        void AddForm(FormsOfTraining form)
        {
            _repository.CreateForm(form, _selectedLevel, _selectedFaculty);
            _closeWindow();
        }
    }
}
