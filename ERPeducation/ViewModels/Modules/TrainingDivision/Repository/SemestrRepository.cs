using ERPeducation.Models;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Repository
{
    public class SemestrRepository : ISemestrRepository
    {
        public ObservableCollection<Semestr> Semestres { get; set; } = new();
        public void AddSemestr() => Semestres.Add(new Semestr()
        {
            Number = 1
        });
        public void DelSemestr(Semestr semestr) => Semestres.Remove(semestr);
    }
}