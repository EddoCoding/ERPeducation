namespace ERPeducation.Models.AdmissionCampaign.Educations
{
    public class EducationEleven : EducationBase
    {
        public string Code { get; set; } = string.Empty;
        public string Series { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;

        public EducationEleven()
        {
            TypeEducation = "Среднее общее образование";
            IdentificationDocument = "Аттестат о среднем общем образовании";
        }
    }
}
