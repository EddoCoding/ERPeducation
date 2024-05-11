using ERPeducation.Models;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Repository
{
    public interface ISemestrRepository
    {
        ObservableCollection<Semestr> Semestres { get; set; }
        void AddSemestr();
        void DelSemestr(Semestr semestr);
    }
}