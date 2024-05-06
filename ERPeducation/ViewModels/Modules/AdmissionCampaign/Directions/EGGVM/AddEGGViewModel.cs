using ERPeducation.Models.AdmissionCampaign.Directions.TestEGG;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Repositories;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions.EGGVM
{
    public class AddEGGViewModel
    {
        public EGE EGG { get; set; } = new();

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<EGE, Unit> AddEGGCommand { get; set; }

        Action _closeWindow;

        IDirectionRepository _repository;
        public AddEGGViewModel(IDirectionRepository repository, Action closeWindow)
        {
            _repository = repository;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddEGGCommand = ReactiveCommand.Create<EGE>(AddEGG);
        }

        void Exit() => _closeWindow();
        void AddEGG(EGE egg)
        {
            _repository.CreateEGG(egg);
            _closeWindow();
        }
    }
}