using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents
{
    public class PassportViewModel : ReactiveObject
    {
        public Passport Passport { get; set; } = new();

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Passport, Unit> AddDocumentCommand { get; set; }

        Action closeWindow;

        IEnrolleeRepository _repository;
        public PassportViewModel(IEnrolleeRepository repository, Action closeWindow) 
        {
            _repository = repository;
            this.closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddDocumentCommand = ReactiveCommand.Create<Passport>(AddDocument);
        }

        void Exit() => closeWindow();
        void AddDocument(Passport passport)
        {
            _repository.CreateDocument(passport);
            closeWindow();
        }
    }
}