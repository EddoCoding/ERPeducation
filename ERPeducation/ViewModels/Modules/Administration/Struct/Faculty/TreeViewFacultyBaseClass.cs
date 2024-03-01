using ReactiveUI;
using System.Reactive;
using System.Text.Json.Serialization;

namespace ERPeducation.ViewModels.Modules.Administration.Struct.Faculty
{
    public class TreeViewFacultyBaseClass : ReactiveObject
    {
        public string Title { get; set; }

        [JsonIgnore] public ReactiveCommand<Unit, Unit> Add { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit, Unit> Del { get; set; }
    }
}