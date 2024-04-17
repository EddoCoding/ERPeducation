using ERPeducation.Models;
using ERPeducation.ViewModels.Modules.TrainingDivision;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Windows.WindowAddSyllabus
{
    public interface ISyllabus
    {
        void OpenWindowAddSyllabus(ObservableCollection<SyllabusVM> syllabus);
        void SerializationSyllabus(SyllabusVM syllabus);
        ICollection<SyllabusModel> DeserializationSyllabus();
        void SettingSyllabus(SyllabusVM syllabus);
        void DeleteSyllabus(SyllabusVM syllabus);
    }
}