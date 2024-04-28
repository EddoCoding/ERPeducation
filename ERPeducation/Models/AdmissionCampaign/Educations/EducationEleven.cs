namespace ERPeducation.Models.AdmissionCampaign.Educations
{
    public class EducationEleven : EducationBase
    {
        public string Code { get; set; } = "Код Eleven";
        public string Series { get; set; } = "Серия Eleven";
        public string Number { get; set; } = "Номер Eleven";

        public EducationEleven()
        {
            TypeEducation = "Среднее общее образование";
            IdentificationDocument = "Аттестат о среднем общем образовании";
        }
    }
}
