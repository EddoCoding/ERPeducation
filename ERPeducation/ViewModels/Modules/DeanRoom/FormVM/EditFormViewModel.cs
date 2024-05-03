using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.DeanRoom.FormVM
{
    public class EditFormViewModel : ReactiveObject
    {
        public FormsOfTraining OldNameForm { get; set; }
        public FormsOfTraining NewNameForm { get; set; }

        LvlOfTraining _selectedLevel;
        Faculty _selectedFaculty;

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<FormsOfTraining, Unit> EditFormCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public EditFormViewModel(IDeanRoomRepository repository, FormsOfTraining form, LvlOfTraining level, Faculty faculty, Action closeWindow)
        {
            _repository = repository;
            OldNameForm = form;
            _selectedLevel = level;
            _selectedFaculty = faculty;
            _closeWindow = closeWindow;

            NewNameForm = new FormsOfTraining();

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            EditFormCommand = ReactiveCommand.Create<FormsOfTraining>(EditForm);
        }

        void Exit() => _closeWindow();
        void EditForm(FormsOfTraining form)
        {
            NewNameForm.TypeGroups = form.TypeGroups;
            _repository.EditForm(form, NewNameForm, _selectedLevel, _selectedFaculty);
            _closeWindow();
        }
    }
}
