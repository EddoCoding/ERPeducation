using System.IO;

namespace ERPeducation.Common.BD
{
    public static class FileServer
    {
        public static string PathIS = string.Empty;

        public static string IS => Path.Combine(PathIS, "InformationSystems"); //Путь к главной папке проекта


        public static string DeanRoom => Path.Combine(PathIS, IS, "DeanRoom"); //Путь к папке -- Деканат --
        public static string DeanRoomData => Path.Combine(DeanRoom, "DeanRoomData"); //Путь к папке -- Данных для деканата --


        public static string TrainingDivision => Path.Combine(PathIS, IS, "TrainingDivision"); //Путь к папке -- Учбеного отдела --
        public static string Syllabus => Path.Combine(TrainingDivision, "Syllabus"); //Путь к папке -- Учебный планов --
        public static string Schedule => Path.Combine(TrainingDivision, "Schedule"); //Путь к папке -- Расписания --


        public static string AdmissionCampaign => Path.Combine(PathIS, IS, "AdmissionCampaign"); //Путь к папке -- Приёмной кампании --
        public static string Enrollees => Path.Combine(AdmissionCampaign, "Enrollees"); //Путь к папке -- Абитуриентов --


        public static string Administration => Path.Combine(PathIS, IS, "Administration"); //Путь к папке -- Администрирования --
        public static string Users => Path.Combine(Administration, "Users"); //Путь к папке -- Пользователей --
    }
}