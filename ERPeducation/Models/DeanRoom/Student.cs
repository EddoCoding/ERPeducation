using ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.Models.DeanRoom
{
    [JsonObject]
    public class Student
    {
        // -- Личная информация --
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Citizenship { get; set; } = string.Empty;
        public DateTime DateCitizenship { get; set; }

        // -- Контактная информация --
        public string ResidenceAddress { get; set; } = string.Empty;
        public string RegistrationAddress { get; set; } = string.Empty;
        public string HomePhone { get; set; } = string.Empty;
        public string MobilePhone { get; set; } = string.Empty;

        // -- Инфо. об учебной структуре --
        public string TitleFaculty { get; set; } = string.Empty;
        public string TitleLevel { get; set; } = string.Empty;
        public string TitleForm { get; set; } = string.Empty;
        public string TitleTypeGroup { get; set; } = string.Empty;
        public string TitleGroup { get; set; } = string.Empty;
        public string TitleDirection { get; set; } = string.Empty;

        public ObservableCollection<DocumentBase> Documents { get; set; } = new();

        public ObservableCollection<string> qwerty1 { get; set; } = new(); // -- Список предметов, которые сдал --
        public ObservableCollection<string> qwerty2 { get; set; } = new(); // -- Список предметов, которые не сдал --
    }
}