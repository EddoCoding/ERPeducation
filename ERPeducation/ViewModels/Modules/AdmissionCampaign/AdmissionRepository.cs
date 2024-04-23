using ERPeducation.Common.BD;
using ERPeducation.Models.AdmissionCampaign;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class AdmissionRepository : IAdmissionRepository
    {
        public ICollection<Enrollee> GetEnrollees()
        {
            ICollection<Enrollee> enrollees = new List<Enrollee>();
            if (Directory.Exists(FileServer.Enrollees))
            {
                string[] jsonFiles = Directory.GetFiles(FileServer.Enrollees);
                foreach(var file in jsonFiles) 
                    enrollees.Add(JsonConvert.DeserializeObject<Enrollee>(File.ReadAllText(file)));
            }
            return enrollees;
        }
        public void CreateEnrollee()
        {
            throw new System.NotImplementedException();
        }
    }
}
