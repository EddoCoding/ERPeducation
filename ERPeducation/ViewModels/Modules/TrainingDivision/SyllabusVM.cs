using ReactiveUI;
using System.Collections.Generic;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class SyllabusVM
    {
        public string TitleSyllabus { get; set; } = string.Empty;
        public int NumberOfSemester { get; set; }
        public List<SemestrVM> Semesters { get; set; }

        public SyllabusVM(string titleSyllabus = default, int number = default)
        {
            TitleSyllabus = titleSyllabus;
            NumberOfSemester = number;

            Semesters = new List<SemestrVM>();

            for (int i = 0; i < NumberOfSemester; i++)
                Semesters.Add(new SemestrVM($"{i + 1}"));
        }
    }
}