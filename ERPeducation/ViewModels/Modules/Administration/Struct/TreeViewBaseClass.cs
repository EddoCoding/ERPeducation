using Newtonsoft.Json;
using ReactiveUI;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.Administration.Struct
{
    [JsonObject]
    public class TreeViewBaseClass : ReactiveObject
    {
        public string Title { get; set; }

        [JsonIgnore] public ReactiveCommand<Unit, Unit> Add { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit, Unit> Del { get; set; }
    }
}
