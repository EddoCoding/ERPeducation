namespace ERPeducation
{
    public class Check
    {
        public string Q {  get; set; }
        public string W {  get; set; }
        public string E { get; set; }

        public Check(string q, string w)
        {
            E = $"{q}\t{w}";
        }
    }
}
