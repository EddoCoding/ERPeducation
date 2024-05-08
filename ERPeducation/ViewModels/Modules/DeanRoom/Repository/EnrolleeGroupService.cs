using ERPeducation.Common.BD;
using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.Models.DeanRoom;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Repository
{
    public class EnrolleeGroupService : IEnrolleeGroupService
    {
        public ObservableCollection<Enrollee> Enrollees { get; set; }  = new ObservableCollection<Enrollee>();
        public void GetEnrollees(Group group) 
        {
            var files = Directory.GetFiles(FileServer.Enrollees, "*.json");
            if (files.Length > 0)
                foreach (var file in files)
                {
                    var json = File.ReadAllText(file);
                    var enrollee = JsonConvert.DeserializeObject<Enrollee>(json);
                    if (enrollee.Directions[0].NameDirection == group.Direction)
                        Enrollees.Add(enrollee);
                }
        }
    }
}