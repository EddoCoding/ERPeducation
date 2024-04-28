namespace ERPeducation.Models.AdmissionCampaign.Educations
{
    public class EducationBak : EducationBase
    {
        public string FormOfEducation { get; set; } = "Заочная";
        public string RegistrationNumber { get; set; } = "Рег.НомерБак";
        public string DiplomaSeries { get; set; } = "Серия дипломаБак";
        public string DiplomaNumber { get; set; }  = "Номер дипломаБак";
        public string SupplementSeries { get; set; } = "Серия приложенияБак";
        public string SupplementNumber { get; set; } = "Номер приложенияБак";

        public EducationBak()
        {
            TypeEducation = "Бакалавриат";
            IdentificationDocument = "Диплом бакалавра";
        }
    }
}