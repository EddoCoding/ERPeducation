using System.Collections.Generic;

namespace ERPeducation.Models.DeanRoom
{
    public class FormsOfTraining
    {
        public string NameForm { get; set; }
        public List<TypeGroup> TypeGroups { get; set; }
        public string NameLevel { get; set; }

        public FormsOfTraining() => TypeGroups = new List<TypeGroup>();
    }
}