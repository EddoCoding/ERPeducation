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
    public class DepartmentService : IEducationalService<TreeViewDepartment>
    {
        public IJSONService jsonService { get; set; } = new JSONService();

        public IEnumerable<TreeViewDepartment> GetEducationalData(TreeViewBaseClass treeView = default)
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


            ICollection<TreeViewDepartment> departments = new List<TreeViewDepartment>();

            foreach (var item in treeViewMain)
                foreach (var faculty in item.Items)
                { 
                    if(faculty.Title == treeView.Title)
                    {
                        foreach(var department in faculty.Items)
                        {
                            departments.Add(department);
                            break;
                        }
                    }
                }
            return departments;
        }
    }
}
