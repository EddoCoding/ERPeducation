using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents
{
    public class DocumentBase
    {
        public string TypeDocument { get; set; } = string.Empty;
        public string SurName { get; set; } = "Пупкин";
        public string Name { get; set; } = "Василий";
        public string MiddleName { get; set; } = "Петрович";
        public string Gender { get; set; } = "Муж";
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string PlaceOfBirth { get; set; } = "Москва";
    }
}