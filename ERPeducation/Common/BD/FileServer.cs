using System.IO;

namespace ERPeducation.Common.BD
{
    public static class FileServer
    {
        public static string PathIS = string.Empty;

        public static string IS => Path.Combine(PathIS, "InformationSystems");

        public static string Administration => Path.Combine(PathIS, IS, "Administration");

        public static string Users => Path.Combine(Administration, "Users"); //ПОЛЬЗОВАТЕЛИ

        public static string Structures => Path.Combine(Administration, "Structures"); //СТРУКТУРЫ
        public static string About => Path.Combine(Structures, "About"); //Структуры - О институте
        public static string EducationalStructure => Path.Combine(Structures, "EducationalStructure"); //Структуры - Образовательная структура
        public static string Education => Path.Combine(Structures, "Education"); //Структуры - Образования - МОЖЕТ НА УДАЛЕНИЕ
        public static string SpaceManagement => Path.Combine(Structures, "SpaceManagement"); //Структуры - Пространства

        public static string DocumentManagement => Path.Combine(Administration, "DocumentManagement"); //Папка в Administration
        public static string AdmissionsCampaignManagement => Path.Combine(Administration, "AdmissionsCampaignManagement"); //Папка в Administration


        public static string AdmissionCampaign => Path.Combine(PathIS, IS, "AdmissionCampaign"); //ПРИЁМНАЯ КАМПАНИЯ
        public static string Enrollees => Path.Combine(AdmissionCampaign, "Enrollees"); //Приёмная кампания - абитуриенты


        public static string TrainingDivision => Path.Combine(PathIS, IS, "TrainingDivision"); //УЧЕБНЫЙ ОТДЕЛ
        public static string Syllabus => Path.Combine(TrainingDivision, "Syllabus"); //Учебный отдел - Учебные планы
        public static string Schedule => Path.Combine(TrainingDivision, "Schedule"); //Учебный отдел - Расписания



        //БЛОК С ФАЙЛАМИ || БЛОК С ФАЙЛАМИ || БЛОК С ФАЙЛАМИ || БЛОК С ФАЙЛАМИ || БЛОК С ФАЙЛАМИ || БЛОК С ФАЙЛАМИ || БЛОК С ФАЙЛАМИ || БЛОК С ФАЙЛАМИ 
        //БЛОК С ФАЙЛАМИ || БЛОК С ФАЙЛАМИ || БЛОК С ФАЙЛАМИ || БЛОК С ФАЙЛАМИ || БЛОК С ФАЙЛАМИ || БЛОК С ФАЙЛАМИ || БЛОК С ФАЙЛАМИ || БЛОК С ФАЙЛАМИ

        public static string structPathFaculty => Path.Combine(EducationalStructure, "fileFaculty.json"); //ЗДЕСЬ ЛЕЖАТ ФАКУЛЬТЕТЫ, КАФЕДРЫ, ГРУППЫ И СТУДЕНТЫ
        public static string structPathEducation => Path.Combine(Education, "fileEducation.json"); //МОЖЕТ БЫТЬ УДАЛИТЬ


    }
}