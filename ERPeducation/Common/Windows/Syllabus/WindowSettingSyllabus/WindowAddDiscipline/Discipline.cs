using ERPeducation.Common.Command;
using ERPeducation.ViewModels.Modules.TrainingDivision;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Windows.Syllabus.WindowSettingSyllabus.WindowAddDiscipline
{
    public class Discipline : IDiscipline
    {
        public void AddDiscipline(ObservableCollection<DisciplineVM> disciplines)
        {
            AddDisciplineWindow view = new AddDisciplineWindow();
            view.DataContext = new AddDisciplineViewModel(disciplines, view.Close);
            view.ShowDialog();
        }
    }
}