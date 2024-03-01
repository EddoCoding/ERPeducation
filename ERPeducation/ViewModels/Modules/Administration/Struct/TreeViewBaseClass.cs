using ReactiveUI;
using System;
using System.Reactive;
using System.Text.Json.Serialization;

namespace ERPeducation.ViewModels.Modules.Administration.Struct
{
    public class TreeViewBaseClass : ReactiveObject
    {
        public string Title { get; set; }

        [JsonIgnore] public ReactiveCommand<Unit, Unit> Add { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit, Unit> Del { get; set; }
    }
}
