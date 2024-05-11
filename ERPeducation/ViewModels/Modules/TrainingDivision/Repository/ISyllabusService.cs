using ERPeducation.Models;
using ERPeducation.ViewModels.Modules.TrainingDivision.Service;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Repository
{
    public interface ISyllabusService
    {
        void OpenWindowCreateSyllabus(ISyllabusRepository syllabusRepository);
        void OpenWindowEditSyllabus(ISyllabusRepository syllabusRepository, Syllabus syllabus);

        void OpenWindowSettingSyllabus(Syllabus syllabus);
    }
}