namespace ERPeducation.Models.AdmissionCampaign.Educations
{
    public class EducationMag : EducationBase
    {
        public string FormOfEducation { get; set; } = "Очно-Заочная";
        public string RegistrationNumber { get; set; } = "Рег.НомерМаг";
        public string DiplomaSeries { get; set; } = "Серия дипломаМаг";
        public string DiplomaNumber { get; set; }  = "Номер дипломаМаг";
        public string SupplementSeries { get; set; } = "Серия приложенияМаг";
        public string SupplementNumber { get; set; } = "Номер приложенияМаг";

        public EducationMag()
        {
            TypeEducation = "Магистратура";
            IdentificationDocument = "Диплом магистра";
        }
    }
}
