using ERPeducation.Models;
using ERPeducation.ViewModels.Modules.TrainingDivision.Repository;
using ERPeducation.ViewModels.Modules.TrainingDivision.Service;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class TrainingDivisionViewModel : ReactiveObject
    {
        public ObservableCollection<Syllabus> Syllabus { get; set; }

        #region Команды
        public ReactiveCommand<Unit,Unit> CreateSyllabusCommand { get; set; }
        public ReactiveCommand<Syllabus,Unit> EditSyllabusCommand { get; set; }
        public ReactiveCommand<Syllabus,Unit> SettingSyllabusCommand { get; set; }
        public ReactiveCommand<Syllabus,Unit> DelSyllabusCommand { get; set; }
        #endregion

        ISyllabusService _syllabusService = new SyllabusService();
        ISyllabusRepository _syllabusRepository = new SyllabusRepository();
        public TrainingDivisionViewModel()
        {
            Syllabus = new();
            _syllabusRepository.Syllabus.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Syllabus.Add(e.NewItems[0] as Syllabus);
                else if (e.Action == NotifyCollectionChangedAction.Remove) Syllabus.Remove(e.OldItems[0] as Syllabus);
            };
            _syllabusRepository.GetSyllabus();

            CreateSyllabusCommand = ReactiveCommand.Create(createSyllabus);
            EditSyllabusCommand = ReactiveCommand.Create<Syllabus>(editSyllabus);
            SettingSyllabusCommand = ReactiveCommand.Create<Syllabus>(settingSyllabus);
            DelSyllabusCommand = ReactiveCommand.Create<Syllabus>(delSyllabus);
        }

        #region Методы
        void createSyllabus() => _syllabusService.OpenWindowCreateSyllabus(_syllabusRepository);
        void editSyllabus(Syllabus syllabus) => _syllabusService.OpenWindowEditSyllabus(_syllabusRepository, syllabus);
        void settingSyllabus(Syllabus syllabus) => _syllabusService.OpenWindowSettingSyllabus(syllabus);
        void delSyllabus(Syllabus syllabus) => _syllabusRepository.DelSyllabus(syllabus);
        #endregion
    }
}