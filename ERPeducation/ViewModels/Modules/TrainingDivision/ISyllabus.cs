using ERPeducation.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public interface ISyllabus
    {
        ICollection<Syllabus> GetSyllabusCollection();
        void OpenWindowAddSyllabus(ObservableCollection<Syllabus> syllabus);
        Syllabus GetSyllabusModel();
    }
}
