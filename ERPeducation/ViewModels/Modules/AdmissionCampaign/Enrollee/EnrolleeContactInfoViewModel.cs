using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Enrollee
{
    [JsonObject]
    public class EnrolleeContactInfoViewModel : ReactiveObject
    {
        [Reactive] public string ResidenceAddress { get; set; } = string.Empty;
        [Reactive] public string RegistrationAddress { get; set; } = string.Empty;
        [Reactive] public string HomePhone { get; set; } = string.Empty;
        [Reactive] public string MobilePhone { get; set; } = string.Empty;
        [Reactive] public string Mail { get; set; } = string.Empty;
    }
}