using System.Collections.Generic;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class SyllabusVM
    {
        public string TitleSyllabus { get; set; } = string.Empty;
        public int NumberOfSemester { get; set; }
        public List<DisciplineVM> Semesters { get; set; }

        public SyllabusVM(int number = default)
        {
            Semesters = new List<DisciplineVM>();
            NumberOfSemester = number;

            for (int i = 0; i < NumberOfSemester; i++) 
                Semesters.Add(new DisciplineVM());
        }
    }
}