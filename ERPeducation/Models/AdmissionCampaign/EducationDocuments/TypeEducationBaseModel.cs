using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;

namespace ERPeducation.Models.AdmissionCampaign.EducationDocuments
{
    public class TypeEducationBaseModel : ReactiveObject
    {
        public string TypeEducation { get; set; }
        public bool IsBool { get; set; }
        [Reactive] public DateTime DateOfIssue { get; set; }
        [Reactive] public bool IsPopup { get; set; }
        public string IssuedBy { get; set; }
    }
}
