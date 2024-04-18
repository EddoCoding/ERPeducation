namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class DisciplineVM
    {
        public string TitleSubject { get; set; } = string.Empty;
        public int LectureHours { get; set; }
        public int PracticeHours { get; set; }
        public string TypeOfControl { get; set; } = string.Empty;
        //Добавить учебные темы - массив строк или список строк

        public DisciplineVM(string titleSubject, int lectureHours, int practiceHours, string typeOfControl)
        {
            TitleSubject = titleSubject;
            LectureHours = lectureHours;
            PracticeHours = practiceHours;
            TypeOfControl = typeOfControl;
        }
    }
}