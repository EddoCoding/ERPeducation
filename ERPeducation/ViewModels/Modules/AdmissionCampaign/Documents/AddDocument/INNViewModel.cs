using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents
{
    public class INNViewModel
    {
        public INN INN { get; set; } = new();

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<INN, Unit> AddDocumentCommand { get; set; }

        Action closeWindow;

        IEnrolleeRepository _repository;
        public INNViewModel(IEnrolleeRepository repository, Action closeWindow)
        {
            _repository = repository;
            this.closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddDocumentCommand = ReactiveCommand.Create<INN>(AddDocument);
        }

        void Exit() => closeWindow();
        void AddDocument(INN INN)
        {
            _repository.CreateDocument(INN);
            closeWindow();
        }
    }
}
