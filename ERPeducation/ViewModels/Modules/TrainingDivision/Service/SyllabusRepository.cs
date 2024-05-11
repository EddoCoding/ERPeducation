using ERPeducation.Common.BD;
using ERPeducation.Models;
using ERPeducation.Models.DeanRoom;
using Newtonsoft.Json;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.IO;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Service
{
    public class SyllabusRepository : ReactiveObject, ISyllabusRepository
    {
        public ObservableCollection<Syllabus> Syllabus { get; set; } = new();
        public void GetSyllabus()
        {
            var files = Directory.GetFiles(FileServer.Syllabus, "*.json");
            if (files.Length > 0)
                foreach (var file in files)
                {
                    var json = File.ReadAllText(file);
                    var syllabus = JsonConvert.DeserializeObject<Syllabus>(json);
                    Syllabus.Add(syllabus);
                }
        }

        public void CreateSyllabus(Syllabus syllabus)
        {
            Serialization(syllabus);
            Syllabus.Add(syllabus);
        }
        public void EditSyllabus(Syllabus oldSyllabus, Syllabus newSyllabus)
        {
            Serialization(newSyllabus);
            Syllabus.Add(newSyllabus);

            File.Delete(Path.Combine(FileServer.Syllabus, $"{oldSyllabus.TitleSyllabus}.json"));
            Syllabus.Remove(oldSyllabus);
        }
        public void DelSyllabus(Syllabus syllabus)
        {
            if (File.Exists(Path.Combine(FileServer.Syllabus, $"{syllabus.TitleSyllabus}.json")))
            {
                File.Delete(Path.Combine(FileServer.Syllabus, $"{syllabus.TitleSyllabus}.json"));
                Syllabus.Remove(syllabus);
            }
        }

        void Serialization(Syllabus syllabus)
        {
            string json = JsonConvert.SerializeObject(syllabus, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            });
            File.WriteAllText(Path.Combine(FileServer.Syllabus, $"{syllabus.TitleSyllabus}.json"), json);
        }
    }
}