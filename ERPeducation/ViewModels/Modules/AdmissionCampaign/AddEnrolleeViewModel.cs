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
        Enrollee _enrollee;
        public Enrollee Enrollee
        {
            get => _enrollee;
            set => this.RaiseAndSetIfChanged(ref _enrollee, value);
        }

        ObservableCollection<DocumentBase> _documents;
        public ObservableCollection<DocumentBase> Documents
        {
            get => _documents;
            set => this.RaiseAndSetIfChanged(ref _documents, value);
        }



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

            Documents = new ObservableCollection<DocumentBase>();
            _repository.Documents.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                    Documents.Add(e.NewItems[0] as DocumentBase);
            };

            AddDocumentCommand = ReactiveCommand.Create<string>(AddDocument);
            AddEducationCommand = ReactiveCommand.Create(AddEducation);
            AddEnrolleeCommand = ReactiveCommand.Create(AddEnrollee);
        }

        void AddDocument(string typeDocument) => _repository.CreateDocument(typeDocument);
        void AddEducation() { }
        void AddEnrollee() { }
    }
}