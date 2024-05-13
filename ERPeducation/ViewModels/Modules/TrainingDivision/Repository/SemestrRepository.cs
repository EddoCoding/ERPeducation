using ERPeducation.Models;
using ERPeducation.Models.TrainingDivision;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Repository
{
    public class SemestrRepository : ISemestrRepository
    {
        public ObservableCollection<Semestr> Semesters { get; set; } = new();

        public void GetSemesters(Syllabus syllabus) 
        {
            var semesters = syllabus.Semesters.ToList();
            foreach (var semester in semesters) Semesters.Add(semester);
        }
        public void AddSemestr() 
        {
            var semestr = new Semestr() { NumberSemestr = Semesters.Count + 1 };
            Semesters.Add(semestr);
        }
        public void DelSemestr(Semestr semestr) => Semesters.Remove(semestr);


        public void AddDiscipline(Semestr semestr) => semestr.Disciplines.Add(new Discipline());
        public void DelDiscipline(Discipline discipline)
        {
            var disciplinesToRemove = new List<Discipline>();

            foreach (var semestr in Semesters)
                foreach (var dis in semestr.Disciplines)
                    if (dis == discipline) disciplinesToRemove.Add(dis);

            foreach (var disciplineToRemove in disciplinesToRemove)
                foreach (var semestr in Semesters)
                    semestr.Disciplines.Remove(disciplineToRemove);
        }

        public void AddCoursework(Semestr semestr) => semestr.Courseworks.Add(new Coursework());
        public void DelCoursework(Coursework coursework)
        {
            var courseworksToRemove = new List<Coursework>();

            foreach (var semestr in Semesters)
                foreach (var cou in semestr.Courseworks)
                    if (cou == coursework) courseworksToRemove.Add(cou);

            foreach (var courseworkToRemove in courseworksToRemove)
                foreach (var semestr in Semesters)
                    semestr.Courseworks.Remove(courseworkToRemove);
        }
    }
}