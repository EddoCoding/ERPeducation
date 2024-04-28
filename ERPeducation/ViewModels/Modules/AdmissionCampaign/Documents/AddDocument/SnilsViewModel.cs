using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents
{
    public class SnilsViewModel
    {
        public Snils Snils { get; set; } = new();

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Snils, Unit> AddDocumentCommand { get; set; }

        Action closeWindow;

        IEnrolleeRepository _repository;
        public SnilsViewModel(IEnrolleeRepository repository, Action closeWindow)
        {
            _repository = repository;
            this.closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddDocumentCommand = ReactiveCommand.Create<Snils>(AddDocument);
        }

        void Exit() => closeWindow();
        void AddDocument(Snils snils)
        {
            _repository.CreateDocument(snils);
            closeWindow();
        }
    }
}
