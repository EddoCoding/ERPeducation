namespace ERPeducation.Models.AdmissionCampaign.Educations
{
    public class EducationNine : EducationBase
    {
        public string Code { get; set; } = "Код Nine";
        public string Series { get; set; } = "Серия Nine";
        public string Number { get; set; } = "Номер Nine";

        public EducationNine() 
        {
            TypeEducation = "Основное общее образование";
            IdentificationDocument = "Аттестат об основном общем образовании";
        }
    }
}
