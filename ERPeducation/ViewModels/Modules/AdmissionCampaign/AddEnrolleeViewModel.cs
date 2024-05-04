using ERPeducation.Common.Command;
using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.Models.AdmissionCampaign.Direction;
using ERPeducation.Models.AdmissionCampaign.Educations;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions;
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

        #region Команды документов
        public ReactiveCommand<string,Unit> AddDocumentCommand { get; set; }                // --- Добавление документа ---
        public ReactiveCommand<DocumentBase, Unit> EditDocumentCommand { get; set; }        // --- Изменение документа ---
        public ReactiveCommand<DocumentBase, Unit> DelDocumentCommand { get; set; }         // --- Удаление документа ---
        #endregion
        #region Команды образования
        public ReactiveCommand<string, Unit> AddEducationCommand { get; set; }              // --- Добавление образования ---
        public ReactiveCommand<EducationBase, Unit> EditEducationCommand { get; set; }      // --- Изменение образования ---
        public ReactiveCommand<EducationBase, Unit> DelEducationCommand { get; set; }       // --- Удаление образования ---
        #endregion
        #region Команды направления
        public ReactiveCommand<Unit, Unit> AddDirectionCommand { get; set; }              // --- Добавление направления ---
        public ReactiveCommand<Unit, Unit> EditDirectionCommand { get; set; }             // --- Изменение направления ---
        public ReactiveCommand<Unit, Unit> DeleteDirectionCommand { get; set; }           // --- Удаление направления ---
        #endregion
        #region Команда добавления абитуриента
        public ReactiveCommand<Unit,Unit> AddEnrolleeCommand { get; set; }                  // --- Добавление абитуриента ---
        #endregion

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
            _repository.Educations.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                    Enrollee.Educations.Add(e.NewItems[0] as EducationBase);
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                    Enrollee.Educations.Remove(e.OldItems[0] as EducationBase);
            };
            _repository.Directions.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                    Enrollee.Directions.Add(e.NewItems[0] as DirectionOfAdmission);
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                    Enrollee.Directions.Remove(e.OldItems[0] as DirectionOfAdmission);
            };

            #region Команды документов
            AddDocumentCommand = ReactiveCommand.Create<string>(AddDocument);
            EditDocumentCommand = ReactiveCommand.Create<DocumentBase>(EditDocument);
            DelDocumentCommand = ReactiveCommand.Create<DocumentBase>(DelDocument);
            #endregion
            #region Команды образования
            AddEducationCommand = ReactiveCommand.Create<string>(AddEducation);
            EditEducationCommand = ReactiveCommand.Create<EducationBase>(EditEducation);
            DelEducationCommand = ReactiveCommand.Create<EducationBase>(DelEducation);
            #endregion
            #region Команды направления
            AddDirectionCommand = ReactiveCommand.Create(AddDirection);
            EditDirectionCommand = ReactiveCommand.Create(EditDirection);
            DeleteDirectionCommand = ReactiveCommand.Create(DelDirection);
            #endregion
            #region Команда добавления абитуриента
            AddEnrolleeCommand = ReactiveCommand.Create(AddEnrollee);
            #endregion
        }

        #region Методы документов
        void AddDocument(string typeDocument) => _documentService.OpenWindowCreateDocument(_repository, typeDocument);
        void EditDocument(DocumentBase document) => _documentService.OpenWindowEditDocument(document);
        void DelDocument(DocumentBase document) => _repository.DeleteDocument(document);
        #endregion
        #region Методы образования
        void AddEducation(string typeEducation) => _documentService.OpenWindowCreateEducation(_repository, typeEducation);
        void EditEducation(EducationBase education) => _documentService.OpenWindowEditEducation(education);
        void DelEducation(EducationBase education) => _repository.DeleteEducation(education);
        #endregion
        #region Методы документов
        void AddDirection() => _documentService.OpenWindowCreateDirection(_repository);
        void EditDirection() => NotReady.Message();
        void DelDirection() => NotReady.Message();
        #endregion
        #region Метод добавления абитуриента
        void AddEnrollee() => NotReady.Message();
        #endregion
    }
}