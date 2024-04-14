using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.Administration.Struct.Faculty
{
    [JsonObject]
    public class TreeViewGroup : TreeViewBaseClass
    {
        public string GroupNumber { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
        public string LvlOfStudy { get; set; } = string.Empty;
        public string FormOfStudy { get; set; } = string.Empty;
        public int Course { get; set; }
        public DateTime StartDateOfTraining { get; set; }
        public DateTime EndDateOfTraining { get; set; }
        public string Curator { get; set; } = string.Empty;
        public string Headman { get; set; } = string.Empty;
        

        public ObservableCollection<TreeViewStudent> Items { get; set; }

        public TreeViewGroup(string groupNumber)
        {
            Title = groupNumber;
            GroupNumber = groupNumber;
            Items = new ObservableCollection<TreeViewStudent>();
        }
    }
}
