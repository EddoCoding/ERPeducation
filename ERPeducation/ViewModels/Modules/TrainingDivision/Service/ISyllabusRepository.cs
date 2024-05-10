using ERPeducation.Models;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Service
{
    public interface ISyllabusRepository
    {
        ObservableCollection<Syllabus> Syllabus { get; set; }
        void GetSyllabus();
        void CreateSyllabus();
        void EditSyllabus();
        void DelSyllabus();
    }
}