using ERPeducation.ViewModels.Modules.TrainingDivision;
using System.Collections.Generic;

namespace ERPeducation.Models
{
    public class SyllabusModel
    {
        public string TitleSyllabus { get; set; }
        public List<DisciplineVM> Semesters { get; set; }
    }
}