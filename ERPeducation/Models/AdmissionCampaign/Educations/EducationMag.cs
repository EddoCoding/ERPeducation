namespace ERPeducation.Models.AdmissionCampaign.Educations
{
    public class EducationMag : EducationBase
    {
        public string FormOfEducation { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string DiplomaSeries { get; set; } = string.Empty;
        public string DiplomaNumber { get; set; }  = string.Empty;
        public string SupplementSeries { get; set; } = string.Empty;
        public string SupplementNumber { get; set; } = string.Empty;

        public EducationMag()
        {
            TypeEducation = "Магистратура";
            IdentificationDocument = "Диплом магистра";
        }
    }
}
