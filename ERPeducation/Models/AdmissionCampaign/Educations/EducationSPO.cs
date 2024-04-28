namespace ERPeducation.Models.AdmissionCampaign.Educations
{
    public class EducationSPO : EducationBase
    {
        public string FormOfEducation { get; set; } = "Очная";
        public string RegistrationNumber { get; set; } = "Рег.НомерСПО";
        public string DiplomaSeries { get; set; } = "Серия дипломаСПО";
        public string DiplomaNumber { get; set; } = "Номер дипломаСПО";
        public string SupplementSeries { get; set; } = "Серия приложенияСПО";
        public string SupplementNumber { get; set; } = "Номер приложенияСПО";

        public EducationSPO()
        {
            TypeEducation = "Среднее профессиональное образование";
            IdentificationDocument = "Диплом о среднем профессиональном образовании";
        }
    }
}