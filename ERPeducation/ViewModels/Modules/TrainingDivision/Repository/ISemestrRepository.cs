using ERPeducation.Models;
using ERPeducation.Models.TrainingDivision;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Repository
{
    public interface ISemestrRepository
    {
        ObservableCollection<Semestr> Semesters { get; set; }

        void GetSemesters(Syllabus syllabus);
        void AddSemestr();
        void DelSemestr(Semestr semestr);

        void AddDiscipline(Semestr semestr);
        void DelDiscipline(Discipline discipline);

        void AddCoursework(Semestr semestr);
        void DelCoursework(Coursework coursework);
    }
}