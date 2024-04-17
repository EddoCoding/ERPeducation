using ERPeducation.Common.BD;
using ERPeducation.Common.Command;
using ERPeducation.Models;
using ERPeducation.ViewModels.Modules.TrainingDivision;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ERPeducation.Common.Windows.WindowAddSyllabus
{
    public class Syllabus : ISyllabus
    {
        //Открытие окна добавления учебного плана
        public void OpenWindowAddSyllabus(ObservableCollection<SyllabusVM> syllabus)
        {
            AddSyllabusWindow view = new AddSyllabusWindow();
            view.DataContext = new AddSyllabusViewModel(this, syllabus, view.Close);
            view.ShowDialog();
        }

        //Сериализация учебного плана
        public void SerializationSyllabus(SyllabusVM syllabus)
        {
            var model = new SyllabusModel()
            {
                TitleSyllabus = syllabus.TitleSyllabus,
                Semesters = syllabus.Semesters
            };

            string json = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });

            File.WriteAllText(Path.Combine(FileServer.Syllabus, $"{model.TitleSyllabus}.json"), json);
        }

        //Десериализация учебного плана
        public ICollection<SyllabusModel> DeserializationSyllabus()
        {
            ICollection<SyllabusModel> syllabus = new List<SyllabusModel>();

            foreach (var file in Directory.GetFiles(FileServer.Syllabus, "*.json"))
                syllabus.Add(JsonConvert.DeserializeObject<SyllabusModel>(File.ReadAllText(file)));

            return syllabus;
        }

        //Настройка учебного плана
        public void SettingSyllabus(SyllabusVM syllabus) => NotReady.Message();

        //Удаление учебного плана
        public void DeleteSyllabus(SyllabusVM syllabus)
        {
            if (File.Exists(Path.Combine(FileServer.Syllabus, $"{syllabus.TitleSyllabus}.json")))
                File.Delete(Path.Combine(FileServer.Syllabus, $"{syllabus.TitleSyllabus}.json"));
        }
    }
}