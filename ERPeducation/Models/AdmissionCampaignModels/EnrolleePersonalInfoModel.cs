using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System;
using ReactiveUI;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Old.PersonalDocuments;

namespace ERPeducation.Models.AdmissionCampaignModels
{
    public class EnrolleePersonalInfoModel : ReactiveObject
    {
        [Reactive] public string SurName { get; set; } = string.Empty;
        [Reactive] public string Name { get; set; } = string.Empty;
        [Reactive] public string MiddleName { get; set; } = string.Empty;

        [Reactive] public string Gender { get; set; } = string.Empty;
        [Reactive] public DateTime DateOfBirth { get; set; }

        [Reactive] public string Citizenship { get; set; } = string.Empty;
        [Reactive] public DateTime DoCitizenship { get; set; }

        public ObservableCollection<PersonalDocumentBase> Documents { get; set; }
    }
}
