using DynamicData;
using ERPeducation.Common.BD;
using ERPeducation.Models;
using ERPeducation.Models.DeanRoom;
using ERPeducation.Models.TrainingDivision;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ERPeducation.ViewModels.Modules.DeanRoom.GroupVM
{
    public class AcademicPerformanceViewModel
    {
        public ObservableCollection<DataTable> Tables { get; set; } = new();
        public Group Group { get; set; }
        public ObservableCollection<string> FullNames { get; set; } = new();

        public ReactiveCommand<Group, Unit> SaveCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }

        Action _closeWindow;
        public AcademicPerformanceViewModel(Group group, Action closeWindow)
        {
            Group = group;
            _closeWindow = closeWindow;

            SaveCommand = ReactiveCommand.Create<Group>(Save);
            CloseWindowCommand = ReactiveCommand.Create(Exit);

            ShowAcademicPerformance(group);
        }

        void ShowAcademicPerformance(Group group)
        {
            if (!File.Exists(Path.Combine(FileServer.AcademicPerformance, $"{group.NameGroup}.json")))
            {
                var json = File.ReadAllText(Path.Combine(FileServer.Syllabus, $"{group.Syllabus}.json"));
                var syllabus = JsonConvert.DeserializeObject<Syllabus>(json);

                foreach(var semester in syllabus.Semesters)
                {
                    DataTable table = new();
                    foreach (var discipline in semester.Disciplines)
                    {
                        table.Columns.Add(new DataColumn(discipline.NameSubject, typeof(string))
                        {
                            AllowDBNull = false,
                            DefaultValue = ""
                        });
                    }
                    for (int i = 0; i < group.Students.Count; i++) table.Rows.Add();
                    Tables.Add(table);
                }
                foreach(var student in group.Students) FullNames.Add(student.FullName);
            }
            else
            {
                if(File.Exists(Path.Combine(FileServer.AcademicPerformance, $"{group.NameGroup}.json")))
                {
                    var file = File.ReadAllText(Path.Combine(FileServer.AcademicPerformance, $"{group.NameGroup}.json"));
                    Tables = JsonConvert.DeserializeObject<ObservableCollection<DataTable>>(file);
                    foreach (var student in group.Students) FullNames.Add(student.FullName);
                }
            }
        }
        void Save(Group group)
        {
            var file = JsonConvert.SerializeObject(Tables, Formatting.Indented);
            File.WriteAllText(Path.Combine(FileServer.AcademicPerformance, $"{group.NameGroup}.json"), file);
            _closeWindow();
        }
        void Exit() => _closeWindow();
    }
}