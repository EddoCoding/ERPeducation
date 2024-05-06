using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.Models.AdmissionCampaign.Direction;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions.TestVM
{
    public class InputResultTestViewModel
    {
        public DirectionOfAdmission Direction { get; set; } = new();
        public Enrollee Enrollee { get; set; } = new();

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Enrollee, Unit> InputResultCommand { get; set; }

        Action _closeWindow;

        IAdmissionRepository _repository;
        public InputResultTestViewModel(IAdmissionRepository repository, DirectionOfAdmission direction, Enrollee enrollee, Action closeWindow)
        {
            _repository = repository;
            Direction = direction;
            Enrollee = enrollee;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            InputResultCommand = ReactiveCommand.Create<Enrollee>(InputResult);
        }

        void Exit() => _closeWindow();
        void InputResult(Enrollee enrollee)
        {
            _repository.Serialization(enrollee);
            _closeWindow();
        }
    }
}