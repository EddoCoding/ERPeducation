using ERPeducation.Common.BD;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;

namespace ERPeducation.Common.Windows.Syllabus.WindowAddSyllabus
{
    public class AddSyllabusViewModel
    {
        public Models.Syllabus Syllabus { get; set; } = new();
        ObservableCollection<Models.Syllabus> syllabus;

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Models.Syllabus, Unit> AddSyllabusCommand { get; set; }
        Action closeWindow;

        public AddSyllabusViewModel(ObservableCollection<Models.Syllabus> syllabus, Action closeWindow)
        {
            this.syllabus = syllabus;
            this.closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddSyllabusCommand = ReactiveCommand.Create<Models.Syllabus>(AddSyllabus);
        }

        void Exit() => closeWindow();
        void AddSyllabus(Models.Syllabus syllabus)
        {
            var item = new Models.Syllabus()
            {
                TitleSyllabus = syllabus.TitleSyllabus
            };

            var jsonSetting = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };

            File.WriteAllText(Path.Combine(FileServer.Syllabus, $"{item.TitleSyllabus}.json"), JsonConvert.SerializeObject(item, jsonSetting));
            if (File.Exists(Path.Combine(FileServer.Syllabus, $"{item.TitleSyllabus}.json")))
                this.syllabus.Add(item);
            

            closeWindow();
        }
    }
}