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

namespace ERPeducation.ViewModels.Modules.DeanRoom.Old.Services
{
    public class FacultyService : IEducationalService<TreeViewFaculty>
    {
        public IJSONService jsonService { get; set; } = new JSONService();

        public IEnumerable<TreeViewFaculty> GetEducationalData(TreeViewBaseClass treeView = default)
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
            catch { MessageBox.Show("Исключение выпало при получение списка факультетов"); }


            ICollection<TreeViewFaculty> faculties = new List<TreeViewFaculty>();

            foreach (var item in treeViewMain)
                foreach (var faculty in item.Items)
                    faculties.Add(faculty);

            return faculties;
        }
    }
}