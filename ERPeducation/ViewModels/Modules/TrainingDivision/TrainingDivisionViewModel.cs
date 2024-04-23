using ERPeducation.Common.BD;
using ERPeducation.Models;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class TrainingDivisionViewModel
    {
        public Syllabus Syllabus { get; set; }
        public ObservableCollection<Syllabus> SyllabusCollection { get; set; }

        public ReactiveCommand<Unit, Unit> CreateSyllabusCommand { get; set; }
        public ReactiveCommand<Syllabus, Unit> SettingSyllabusCommand { get; set; }
        public ReactiveCommand<Syllabus, Unit> DeleteSyllabusCommand { get; set; }

        ISyllabus _syllabusService;
        public TrainingDivisionViewModel(ISyllabus _syllabusService)
        {
            this._syllabusService = _syllabusService;
            Syllabus = _syllabusService.GetSyllabusModel();

            SyllabusCollection = new ObservableCollection<Syllabus>();

            foreach (var syllabus in _syllabusService.GetSyllabusCollection())
                SyllabusCollection.Add(syllabus);

            CreateSyllabusCommand = ReactiveCommand.Create(CreateSyllabus);
            SettingSyllabusCommand = ReactiveCommand.Create<Syllabus>(s =>
            {

            });
            DeleteSyllabusCommand = ReactiveCommand.Create<Syllabus>(DeleteSyllabus);
        }

        void CreateSyllabus() => _syllabusService.OpenWindowAddSyllabus(SyllabusCollection);
        void DeleteSyllabus(Syllabus syllabus)
        {
            if (File.Exists(Path.Combine(FileServer.Syllabus, $"{syllabus.TitleSyllabus}.json")))
                File.Delete(Path.Combine(FileServer.Syllabus, $"{syllabus.TitleSyllabus}.json"));

            SyllabusCollection.Select(syllabus => syllabus.TitleSyllabus);
        }
    }
}