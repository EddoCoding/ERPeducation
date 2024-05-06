using ERPeducation.Common.BD;
using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.Models.AdmissionCampaign.Direction;
using ERPeducation.Models.AdmissionCampaign.Educations;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Services;
using Newtonsoft.Json;
using ReactiveUI;
using System.Collections.Specialized;
using System.IO;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class EditEnrolleeViewModel : ReactiveObject
    {
        public Enrollee Enrollee { get; set; }

        #region Команды документов
        public ReactiveCommand<string, Unit> AddDocumentCommand { get; set; }                // --- Добавление документа ---
        public ReactiveCommand<DocumentBase, Unit> EditDocumentCommand { get; set; }         // --- Изменение документа ---
        public ReactiveCommand<DocumentBase, Unit> DelDocumentCommand { get; set; }          // --- Удаление документа ---
        #endregion
        #region Команды образования
        public ReactiveCommand<string, Unit> AddEducationCommand { get; set; }              // --- Добавление образования ---
        public ReactiveCommand<EducationBase, Unit> EditEducationCommand { get; set; }      // --- Изменение образования ---
        public ReactiveCommand<EducationBase, Unit> DelEducationCommand { get; set; }       // --- Удаление образования ---
        #endregion
        #region Команды направления
        public ReactiveCommand<Unit, Unit> AddDirectionCommand { get; set; }                              // --- Добавление направления ---
        public ReactiveCommand<DirectionOfAdmission, Unit> DeleteDirectionCommand { get; set; }           // --- Удаление направления ---
        #endregion
        #region Команда добавления абитуриента
        public ReactiveCommand<Enrollee, Unit> EditEnrolleeCommand { get; set; }           // --- Изменение абитуриента ---
        #endregion

        IAdmissionRepository _admissionRepository;
        IEnrolleeDocumentService _documentService;
        IEnrolleeRepository _repository;
        public EditEnrolleeViewModel(IAdmissionRepository dataRepository, IEnrolleeDocumentService documentService, IEnrolleeRepository repository, Enrollee enrollee)
        {
            _admissionRepository = dataRepository;
            _documentService = documentService;
            _repository = repository;
            Enrollee = enrollee;

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
            DeleteDirectionCommand = ReactiveCommand.Create<DirectionOfAdmission>(DelDirection);
            #endregion
            #region Команда изменения абитуриента
            EditEnrolleeCommand = ReactiveCommand.Create<Enrollee>(EditEnrollee);
            #endregion
        }

        #region Методы документов
        void AddDocument(string typeDocument) => _documentService.OpenWindowCreateDocument(_repository, typeDocument);
        void EditDocument(DocumentBase document) => _documentService.OpenWindowEditDocument(document);
        void DelDocument(DocumentBase document) => Enrollee.Documents.Remove(document);
        #endregion
        #region Методы образования
        void AddEducation(string typeEducation) => _documentService.OpenWindowCreateEducation(_repository, typeEducation);
        void EditEducation(EducationBase education) => _documentService.OpenWindowEditEducation(education);
        void DelEducation(EducationBase education) => Enrollee.Educations.Remove(education);
        #endregion
        #region Методы направлений
        void AddDirection() => _documentService.OpenWindowCreateDirection(_repository);
        void DelDirection(DirectionOfAdmission direction) => Enrollee.Directions.Remove(direction);
        #endregion

        void EditEnrollee(Enrollee enrollee)
        {
            JsonSerializerSettings jsonSetting = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };
            
            if (Directory.Exists(FileServer.Enrollees))
                using (StreamWriter file = File.CreateText(Path.Combine(FileServer.Enrollees, $"{enrollee.SurName}{enrollee.Name}{enrollee.MiddleName}.json")))
                {
                    file.Write(JsonConvert.SerializeObject(enrollee, jsonSetting));
                }
        }
    }
}
