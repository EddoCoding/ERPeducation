namespace ERPeducation.Models.AdmissionCampaign.Educations
{
    public class EducationAsp : EducationBase
    {
        public string FormOfEducation { get; set; } = "жопка";
        public string RegistrationNumber { get; set; } = "Рег.НомерАсп";
        public string DiplomaSeries { get; set; } = "Серия дипломаАсп";
        public string DiplomaNumber { get; set; }  = "Номер дипломаАсп";
        public string SupplementSeries { get; set; } = "Серия приложенияАсп";
        public string SupplementNumber { get; set; } = "Номер приложенияАсп";

        public EducationAsp()
        {
            TypeEducation = "Аспирантура";
            IdentificationDocument = "Диплом аспирантуры";
        }
    }
}