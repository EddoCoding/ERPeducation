using ERPeducation.ViewModels.Modules.TrainingDivision;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Windows.Syllabus.WindowSettingSyllabus.WindowAddDiscipline
{
    public interface IDiscipline
    {
        void AddDiscipline(ObservableCollection<DisciplineVM> disciplines);
    }
}