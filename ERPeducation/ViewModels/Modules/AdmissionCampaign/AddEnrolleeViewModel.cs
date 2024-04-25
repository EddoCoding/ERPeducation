using ERPeducation.Common.Command;
using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Old.EducationDocuments;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Old.PersonalDocuments;
using ReactiveUI;
using System.Collections.Generic;
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

        ObservableCollection<PersonalDocumentBase> _documents;
        public ObservableCollection<PersonalDocumentBase> Documents
        {
            get => _documents;
            set => this.RaiseAndSetIfChanged(ref _documents, value);
        }



        //Добавить логику для радиобатонов


        #region Команды для документов
        public ReactiveCommand<Unit,Unit> AddPassportCommand { get; set; }
        public ReactiveCommand<Unit,Unit> AddSnilsCommand { get; set; }
        public ReactiveCommand<Unit,Unit> AddINNCommand { get; set; }
        public ReactiveCommand<Unit,Unit> AddForeignPassportCommand { get; set; }
        #endregion
        #region Команды для образований
        public ReactiveCommand<Unit, Unit> AddNineCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AddElevenCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AddSPOCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AddBAKCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AddMAGCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AddASPCommand { get; set; }
        #endregion
        #region Команда добавления абитуриента
        public ReactiveCommand<Unit,Unit> AddEnrollee { get; set; }
        #endregion


        IAdmissionRepository _admissionRepository;
        IEnrolleeService _repository;
        public AddEnrolleeViewModel(IAdmissionRepository dataRepository, IEnrolleeService repository, ObservableCollection<Enrollee> enrollees)
        {
            _admissionRepository = dataRepository;
            _repository = repository;



            Documents = new ObservableCollection<PersonalDocumentBase>();
            _repository.Documents.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                    Documents.Add(e.NewItems[0] as PersonalDocumentBase);
            };

            //Доделать репоизторий абитуриента


            #region Команды добавления документов
            AddPassportCommand = ReactiveCommand.Create(NotReady.Message);
            AddSnilsCommand = ReactiveCommand.Create(NotReady.Message);
            AddINNCommand = ReactiveCommand.Create(NotReady.Message);
            AddForeignPassportCommand = ReactiveCommand.Create(NotReady.Message);
            #endregion
            #region Команды добавления образования
            AddNineCommand = ReactiveCommand.Create(NotReady.Message);
            AddElevenCommand = ReactiveCommand.Create(NotReady.Message);
            AddSPOCommand = ReactiveCommand.Create(NotReady.Message);
            AddBAKCommand = ReactiveCommand.Create(NotReady.Message);
            AddMAGCommand = ReactiveCommand.Create(NotReady.Message);
            AddASPCommand = ReactiveCommand.Create(NotReady.Message);
            #endregion
            #region Команда добавления абитуриента
            AddEnrollee = ReactiveCommand.Create(NotReady.Message);
            #endregion
        }
    }
}