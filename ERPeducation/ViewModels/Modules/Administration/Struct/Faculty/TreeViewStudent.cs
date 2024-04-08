using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.Administration.Struct.Faculty
{
    [JsonObject]
    public class TreeViewStudent
    {
        public string Title { get; set; }

        public TreeViewStudent(string title) => Title = title;
    }
}
