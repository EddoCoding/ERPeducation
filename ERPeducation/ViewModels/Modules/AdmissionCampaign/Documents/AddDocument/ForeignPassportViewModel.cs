using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents
{
    public class ForeignPassportViewModel
    {
        public ForeignPassport ForeignPassport { get; set; } = new();

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<ForeignPassport, Unit> AddDocumentCommand { get; set; }

        Action closeWindow;

        IEnrolleeRepository _repository;
        public ForeignPassportViewModel(IEnrolleeRepository repository, Action closeWindow)
        {
            _repository = repository;
            this.closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddDocumentCommand = ReactiveCommand.Create<ForeignPassport>(AddDocument);
        }

        void Exit() => closeWindow();
        void AddDocument(ForeignPassport foreignPassport)
        {
            _repository.CreateDocument(foreignPassport);
            closeWindow();
        }
    }
}
