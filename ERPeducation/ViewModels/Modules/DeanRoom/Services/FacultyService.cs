using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Services
{
    public class FacultyService : IEducationalService
    {
        public IJSONService jsonService { get; set; } = new JSONService();

        public IEnumerable<TreeViewFaculty> GetEducationalData()
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }


            ICollection<TreeViewFaculty> faculties = new List<TreeViewFaculty>();

            foreach (var item in treeViewMain)
                foreach (var faculty in item.Items)
                    faculties.Add(faculty);

            return faculties;
        }
    }
}