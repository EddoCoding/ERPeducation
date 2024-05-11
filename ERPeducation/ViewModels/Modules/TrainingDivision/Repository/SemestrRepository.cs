using ERPeducation.Models;
using System.Collections.ObjectModel;
using System.Linq;

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
    }
}