namespace ERPeducation.Models.AdmissionCampaign.Educations
{
    public class EducationSPO : EducationBase
    {
        public string FormOfEducation { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string DiplomaSeries { get; set; } = string.Empty;
        public string DiplomaNumber { get; set; } = string.Empty;
        public string SupplementSeries { get; set; } = string.Empty;
        public string SupplementNumber { get; set; } = string.Empty;

        public EducationSPO()
        {
            TypeEducation = "Среднее профессиональное образование";
            IdentificationDocument = "Диплом о среднем профессиональном образовании";
        }
    }
}