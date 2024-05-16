using ERPeducation.Models;
using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.TrainingDivision.Repository;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Service
{
    public interface ISyllabusService
    {
        void OpenWindowCreateSyllabus(ISyllabusRepository syllabusRepository);
        void OpenWindowEditSyllabus(ISyllabusRepository syllabusRepository, Syllabus syllabus);
        void OpenWindowShowSyllalbus(Syllabus syllabus, Group group);

        void OpenWindowSettingSyllabus(Syllabus syllabus);
    }
}