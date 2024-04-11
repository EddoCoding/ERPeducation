using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;
using ERPeducation.ViewModels.Modules.Administration.Struct;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Services
{
    public class StudentService : IEducationalService<TreeViewStudent>
    {
        public IJSONService jsonService { get; set; } = new JSONService();

        public IEnumerable<TreeViewStudent> GetEducationalData(TreeViewBaseClass treeView = null)
        {
            ObservableCollection<TreeViewMain> treeViewMain = new ObservableCollection<TreeViewMain>();
            try
            {
                using (var fs = new FileStream(FileServer.structPathFaculty, FileMode.Open))
                {
                    using (var sr = new StreamReader(fs))
                    {
                        treeViewMain = JsonConvert.DeserializeObject<ObservableCollection<TreeViewMain>>(sr.ReadToEnd());
                    }
                }
            }
            catch { MessageBox.Show("Исключение выпало при перечислении списка факультетов"); }

            ICollection<TreeViewStudent> students = new List<TreeViewStudent>();

            foreach (var main in treeViewMain)
                foreach (var faculties in main.Items)
                    foreach (var departments in faculties.Items)
                        foreach(var groups in departments.Items)
                            if (groups.Title == treeView.Title)
                                foreach (var student in groups.Items)
                                    students.Add(student);

            return students;
        }
    }
}