using System;

namespace ERPeducation.Models.AdmissionCampaign.Educations
{
    public class EducationBase
    {
        public string TypeEducation { get; set; } = string.Empty;                         // -- Тип образования --
        public string IdentificationDocument { get; set; } = string.Empty;                // -- Удостоверяющий документ --
        public string IssuedBy { get; set; } = "Для проверки";                            // -- Кем выдан --
        public DateTime DateOfIssue { get; set; } = DateTime.Now;                         // -- Дата выдачи --
        public bool Honours { get; set; } = true;                                         // -- С отличием -- 
        public string AdditionalInformation { get; set; } = "Для проверки";               // -- Дополнительная информация --
    }
}