using ERPeducation.Models;
using ERPeducation.ViewModels.Modules.TrainingDivision.Repository;
using ERPeducation.ViewModels.Modules.TrainingDivision.Service;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class TrainingDivisionViewModel : ReactiveObject
    {
        public ObservableCollection<Syllabus> Syllabus { get; set; }

        public ReactiveCommand<Unit,Unit> CreateSyllabusCommand { get; set; }
        public ReactiveCommand<Unit,Unit> EditSyllabusCommand { get; set; }
        public ReactiveCommand<Unit,Unit> DelSyllabusCommand { get; set; }

        ISyllabusService _syllabusService;
        ISyllabusRepository _syllabusRepository;
        public TrainingDivisionViewModel()
        {
            _syllabusRepository = new SyllabusRepository();
            _syllabusService = new SyllabusService();

            Syllabus = new();
            _syllabusRepository.Syllabus.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Syllabus.Add(e.NewItems[0] as Syllabus);
                else if (e.Action == NotifyCollectionChangedAction.Remove) Syllabus.Remove(e.OldItems[0] as Syllabus);
            };
            _syllabusRepository.GetSyllabus();

            CreateSyllabusCommand = ReactiveCommand.Create(createSyllabus);
            EditSyllabusCommand = ReactiveCommand.Create(editSyllabus);
            DelSyllabusCommand = ReactiveCommand.Create(delSyllabus);
        }

        void createSyllabus() { }
        void editSyllabus() { }
        void delSyllabus() { }
    }
}