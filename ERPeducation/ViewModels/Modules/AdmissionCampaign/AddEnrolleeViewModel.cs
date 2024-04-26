using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Services;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class AddEnrolleeViewModel : ReactiveObject
    {
        public Enrollee Enrollee { get; set; } = new();


        //Добавить логику для радиобатонов


        public ReactiveCommand<string,Unit> AddDocumentCommand { get; set; }        // --- Добавление документов ---
        public ReactiveCommand<Unit, Unit> AddEducationCommand { get; set; }        // --- Добавление образования ---
        public ReactiveCommand<Unit,Unit> AddEnrolleeCommand { get; set; }          // --- Добавление абитуриента ---


        IAdmissionRepository _admissionRepository;
        IEnrolleeDocumentService _documentService;
        IEnrolleeRepository _repository;
        public AddEnrolleeViewModel(IAdmissionRepository dataRepository, IEnrolleeDocumentService documentService, IEnrolleeRepository repository, ObservableCollection<Enrollee> enrollees)
        {
            _admissionRepository = dataRepository;
            _documentService = documentService;
            _repository = repository;

            _repository.Documents.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                    Enrollee.Documents.Add(e.NewItems[0] as DocumentBase);
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                    Enrollee.Documents.Remove(e.OldItems[0] as DocumentBase);
            };

            AddDocumentCommand = ReactiveCommand.Create<string>(AddDocument);
            AddEducationCommand = ReactiveCommand.Create(AddEducation);
            AddEnrolleeCommand = ReactiveCommand.Create(AddEnrollee);
        }

        void AddDocument(string typeDocument) => _documentService.OpenWindowCreateDocument(_repository, typeDocument);
        void AddEducation() { }
        void AddEnrollee() { }
    }
}