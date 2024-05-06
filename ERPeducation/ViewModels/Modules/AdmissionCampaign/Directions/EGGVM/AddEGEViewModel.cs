using ERPeducation.Models.AdmissionCampaign.Directions.TestEGG;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Repositories;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions.EGGVM
{
    public class AddEGEViewModel
    {
        public EGE EGE { get; set; } = new();

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<EGE, Unit> AddEGECommand { get; set; }

        Action _closeWindow;

        IDirectionRepository _repository;
        public AddEGEViewModel(IDirectionRepository repository, Action closeWindow)
        {
            _repository = repository;
            _closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddEGECommand = ReactiveCommand.Create<EGE>(AddEGE);
        }

        void Exit() => _closeWindow();
        void AddEGE(EGE ege)
        {
            _repository.CreateEGG(ege);
            _closeWindow();
        }
    }
}