using System.Collections.ObjectModel;

namespace ERPeducation.Models
{
    public class Semestr
    {
        public int Number { get; set; }
        public ObservableCollection<string>? Disciplines { get; set; }
    }
}
