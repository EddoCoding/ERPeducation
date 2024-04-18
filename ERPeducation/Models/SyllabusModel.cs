using ERPeducation.ViewModels.Modules.TrainingDivision;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ERPeducation.Models
{
    public class SyllabusModel
    {
        public string TitleSyllabus { get; set; } = string.Empty;
        public int NumberOfSemester { get; set; }
        public List<SemestrVM>? Semesters { get; set; }
    }
}