using System.Collections.Generic;

namespace ERPeducation.Models.DeanRoom
{
    public class TypeGroup
    {
        public string NameType { get; set; }
        public List<Group> Groups { get; set; }
        public string NameForm { get; set; }

        public TypeGroup() => Groups = new List<Group>();
    }
}