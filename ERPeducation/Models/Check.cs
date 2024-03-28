using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ERPeducation.Models
{
    public class Check : ReactiveObject
    {
        [Reactive] public string SelectedSee { get; set; }
        [Reactive] public int Quantity { get; set; }
    }
}
