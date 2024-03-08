namespace ERPeducation.Models
{
    public class UserModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;

        //ДОСТУПЫ К МОДУЛЯМ
        public bool RectorAccess { get; set; }
        public bool DeanRoomAccess { get; set; }
        public bool TrainingDivisionAccess { get; set; }
        public bool TeacherAccess { get; set; }
        public bool AdmissionCampaignAccess { get; set; }
        public bool AdministrationAccess { get; set; }

        public UserModel(string fullname, string identifier, bool rectorAccess, bool deanRoomAccess, 
            bool trainingDivisionAccess, bool teacherAccess, bool admissionCampaignAccess, bool administrationAccess)
        {
            FullName = fullname;
            Identifier = identifier;

            RectorAccess = rectorAccess;
            DeanRoomAccess = deanRoomAccess;
            TrainingDivisionAccess = trainingDivisionAccess;
            TeacherAccess = teacherAccess;
            AdmissionCampaignAccess = admissionCampaignAccess;
            AdministrationAccess = administrationAccess;
        }
    }
}
