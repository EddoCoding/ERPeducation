namespace ERPeducation.Models.AdmissionCampaign
{
    public class Enrollee
    {
        public string SurName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }

        public Enrollee(string surName, string name, string middleName)
        {
            SurName = surName;
            Name = name;
            MiddleName = middleName;
            FullName = $"{surName} {name} {middleName}";
        }
    }
}