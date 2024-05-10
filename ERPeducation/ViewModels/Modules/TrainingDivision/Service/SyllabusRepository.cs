using ERPeducation.Common.BD;
using ERPeducation.Models;
using ERPeducation.Models.DeanRoom;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Service
{
    public class SyllabusRepository : ISyllabusRepository
    {
        ObservableCollection<Syllabus> _syllabus;
        public ObservableCollection<Syllabus> Syllabus { get; set; } = new();
        public void GetSyllabus()
        {
            var files = Directory.GetFiles(FileServer.DeanRoomData, "*.json");
            if (files.Length > 0)
                foreach (var file in files)
                {
                    var json = File.ReadAllText(file);
                    var syllabus = JsonConvert.DeserializeObject<Syllabus>(json);
                    _syllabus.Add(syllabus);
                }
        }

        public void CreateSyllabus() { }
        public void EditSyllabus() { }
        public void DelSyllabus() { }
    }
}