using Newtonsoft.Json;
using System;

namespace ERPeducation.ViewModels.Modules.Administration.Struct.Faculty
{
    [JsonObject]
    public class TreeViewStudent
    {
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Group { get; set; } = string.Empty;
        public int Course { get; set; }
        public string Speciality { get; set; } = string.Empty;
        public string LevelOfTraining { get; set; } = string.Empty;
        public string FormOfStudy { get; set; } = string.Empty;

        public TreeViewStudent(string surName, string name, string middleName) 
        {
            (SurName, Name, MiddleName) = (surName, name, middleName);
            FullName = $"{SurName} {Name} {MiddleName}";
        } 
    }
}