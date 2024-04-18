using ERPeducation.Common.Windows.Syllabus.WindowAddSyllabus;
using ERPeducation.Models;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class TrainingDivisionViewModel
    {
        public ObservableCollection<SyllabusVM> Syllabus { get; set; }

        public ReactiveCommand<Unit, Unit> CreateSyllabusCommand { get; set; }
        public ReactiveCommand<SyllabusVM, Unit> SettingSyllabusCommand { get; set; }
        public ReactiveCommand<SyllabusVM, Unit> DeleteSyllabusCommand { get; set; }

        ISyllabus _syllabus;
        public TrainingDivisionViewModel(ISyllabus syllabus)
        {
            _syllabus = syllabus;
            Syllabus = new ObservableCollection<SyllabusVM>();

            GetAllSyllabus();

            CreateSyllabusCommand = ReactiveCommand.Create(CreateSyllabus);
            SettingSyllabusCommand = ReactiveCommand.Create<SyllabusVM>(SettingSyllabus);
            DeleteSyllabusCommand = ReactiveCommand.Create<SyllabusVM>(DeleteSyllabus);
        }

        void GetAllSyllabus()
        {
            foreach (var item in _syllabus.DeserializationSyllabus())
                Syllabus.Add(new SyllabusVM()
                {
                    TitleSyllabus = item.TitleSyllabus,
                    Semesters = item.Semesters
                });
        }
        void CreateSyllabus()
        {
            _syllabus.OpenWindowAddSyllabus(Syllabus);
            Syllabus.Clear();
            GetAllSyllabus();
        }
        void SettingSyllabus(SyllabusVM syllabus) => _syllabus.SettingSyllabus(syllabus);
        void DeleteSyllabus(SyllabusVM syllabus) 
        {
            var itemSyllabus = Syllabus.FirstOrDefault(x => x.TitleSyllabus == syllabus.TitleSyllabus);
            if (itemSyllabus is not null)
                _syllabus.DeleteSyllabus(itemSyllabus);

            Syllabus.Clear();
            GetAllSyllabus();
        }
    }
}