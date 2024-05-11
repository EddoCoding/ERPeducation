using ERPeducation.Models;
using ERPeducation.ViewModels.Modules.TrainingDivision.Service;
using ERPeducation.ViewModels.Modules.TrainingDivision.SyllabusVM;
using ERPeducation.Views.TrainingDivision;
using ERPeducation.Views.TrainingDivision.WindowSyllabus;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Repository
{
    public class SyllabusService : ISyllabusService
    {
        public void OpenWindowCreateSyllabus(ISyllabusRepository syllabusRepository)
        {
            CreateSyllabusWindow syllabusWindow = new CreateSyllabusWindow();
            syllabusWindow.DataContext = new CreateSyllabusViewModel(syllabusRepository, syllabusWindow.Close);
            syllabusWindow.ShowDialog();
        }
        public void OpenWindowEditSyllabus(ISyllabusRepository syllabusRepository, Syllabus syllabus)
        {
            EditSyllabusWindow editSyllabusWindow = new EditSyllabusWindow();
            editSyllabusWindow.DataContext = new EditSyllabusViewModel(syllabusRepository, syllabus, editSyllabusWindow.Close);
            editSyllabusWindow.ShowDialog();
        }

        public void OpenWindowSettingSyllabus(Syllabus syllabus)
        {
            SettingSyllabusWindow window = new();
            window.DataContext = new SettingSyllabusViewModel(syllabus, window.Close);
            window.ShowDialog();
        }
    }
}