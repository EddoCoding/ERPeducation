using ERPeducation.Models.AdmissionCampaign.Directions.TestEGG;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Repositories;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions.TestVM
{
    public class AddTestViewModel
    {
        public Test Test { get; set; } = new();

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Test, Unit> AddTestCommand { get; set; }

        Action _closeWindow;

        IDirectionRepository _repository;
        public AddTestViewModel(IDirectionRepository repository, Action closeWindow)
        {
            _repository = repository;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddTestCommand = ReactiveCommand.Create<Test>(AddTest);
        }

        void Exit() => _closeWindow();
        void AddTest(Test test)
        {
            _repository.CreateTest(test);
            _closeWindow();
        }
    }
}