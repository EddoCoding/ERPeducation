using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ERPeducation.Models
{
    [JsonObject]
    public class Syllabus
    {
        public string TitleSyllabus { get; set; } = string.Empty;
        public ObservableCollection<Semestr> Semesters { get; set; } = new();
    }
}