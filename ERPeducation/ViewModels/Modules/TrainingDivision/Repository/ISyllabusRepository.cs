using ERPeducation.Models;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Repository
{
    public interface ISyllabusRepository
    {
        ObservableCollection<Syllabus> Syllabus { get; set; }
        void GetSyllabus();
        void CreateSyllabus(Syllabus syllabus);
        void EditSyllabus(Syllabus oldSyllabus, Syllabus newSyllabus);
        void DelSyllabus(Syllabus syllabus);
    }
}