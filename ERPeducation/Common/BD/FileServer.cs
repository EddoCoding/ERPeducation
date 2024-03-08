using System.IO;

namespace ERPeducation.Common.BD
{
    public static class FileServer
    {
        public static string PathIS = string.Empty;

        public static string IS => Path.Combine(PathIS, "InformationSystems");

        public static string Administration => Path.Combine(PathIS, IS, "Administration");

        public static string Users => Path.Combine(Administration, "Users");

        public static string Structures => Path.Combine(Administration, "Structures");
        public static string About => Path.Combine(Structures, "About");
        public static string EducationalStructure => Path.Combine(Structures, "EducationalStructure");
        public static string Education => Path.Combine(Structures, "Education");
        public static string SpaceManagement => Path.Combine(Structures, "SpaceManagement");

        public static string DocumentManagement => Path.Combine(Administration, "DocumentManagement");
        public static string AdmissionsCampaignManagement => Path.Combine(Administration, "AdmissionsCampaignManagement");



        public static string structPathFaculty = "C:\\Users\\79613\\Desktop\\БД\\fileFaculty.json";
        public static string structPathEducation = "C:\\Users\\79613\\Desktop\\БД\\fileEducation.json";
    }
}