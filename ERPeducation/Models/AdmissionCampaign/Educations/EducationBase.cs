using System;

namespace ERPeducation.Models.AdmissionCampaign.Educations
{
    public class EducationBase
    {
        public string TypeEducation { get; set; } = string.Empty;                         // -- Тип образования --
        public string IdentificationDocument { get; set; } = string.Empty;                // -- Удостоверяющий документ --
        public string IssuedBy { get; set; } = string.Empty;                              // -- Кем выдан --
        public DateTime DateOfIssue { get; set; }                                         // -- Дата выдачи --
        public bool Honours { get; set; }                                                 // -- С отличием -- 
        public string AdditionalInformation { get; set; } = string.Empty;                 // -- Дополнительная информация --
    }
}