namespace ERPeducation.Models.AdmissionCampaign.Educations
{
    public class EducationNine : EducationBase
    {
        public string Code { get; set; } = string.Empty;
        public string Series { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;

        public EducationNine() 
        {
            TypeEducation = "Основное общее образование";
            IdentificationDocument = "Аттестат об основном общем образовании";
        }
    }
}
