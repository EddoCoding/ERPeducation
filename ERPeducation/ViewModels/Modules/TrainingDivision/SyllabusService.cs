using ERPeducation.Common.BD;
using ERPeducation.Common.Windows.Syllabus.WindowAddSyllabus;
using ERPeducation.Common.Windows.WindowAddSyllabus;
using ERPeducation.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class SyllabusService : ISyllabus
    {
        //Возвращаем учебные планы
        public ICollection<Syllabus> GetSyllabusCollection()
        {
            ICollection<Syllabus> syllabus = new List<Syllabus>();
            if (Directory.Exists(FileServer.Syllabus))
            {
                string[] jsonFiles = Directory.GetFiles(FileServer.Syllabus, "*.json");

                foreach(var filePath in jsonFiles)
                {
                    try
                    {
                        var jsonContent = File.ReadAllText(filePath);
                        syllabus.Add(JsonConvert.DeserializeObject<Syllabus>(jsonContent));
                    }
                    catch(Exception ex) 
                    {
                        MessageBox.Show($"Исключение при обработке файла {filePath} {ex.Message}");
                    }
                }
            }

            return syllabus;
        }

        //Открыаем окно где добавляется учебный план
        public void OpenWindowAddSyllabus(ObservableCollection<Syllabus> syllabus)
        {
            AddSyllabusWindow view = new AddSyllabusWindow();
            view.DataContext = new AddSyllabusViewModel(syllabus, view.Close);
            view.ShowDialog();
        }

        //Возвращаем модель - для инициализации
        public Syllabus GetSyllabusModel() => new Syllabus();
    }
}