using System.IO;

namespace ERPeducation.Common.BD
{
    public static class FileServer
    {
        public static string PathIS = string.Empty;

        public static string IS => Path.Combine(PathIS, "InformationSystems");

        public static string Administration => Path.Combine(PathIS, IS, "Administration");

        public static string Users => Path.Combine(Administration, "Users"); //Папка в Administration

        public static string Structures => Path.Combine(Administration, "Structures"); //Папка в Administration
        public static string About => Path.Combine(Structures, "About"); //Папка в Structures
        public static string EducationalStructure => Path.Combine(Structures, "EducationalStructure"); //Папка в Structures
        public static string Education => Path.Combine(Structures, "Education"); //Папка в Structures
        public static string SpaceManagement => Path.Combine(Structures, "SpaceManagement"); //Папка в Structures

        public static string DocumentManagement => Path.Combine(Administration, "DocumentManagement"); //Папка в Administration
        public static string AdmissionsCampaignManagement => Path.Combine(Administration, "AdmissionsCampaignManagement"); //Папка в Administration


        public static string AdmissionCampaign => Path.Combine(PathIS, IS, "AdmissionCampaign");
        public static string Enrollees => Path.Combine(AdmissionCampaign, "Enrollees");
         

        public static string structPathFaculty => Path.Combine(EducationalStructure, "fileFaculty.json");
        public static string structPathEducation => Path.Combine(Education, "fileEducation.json");
    }
}