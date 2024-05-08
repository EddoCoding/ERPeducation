using ERPeducation.Common.BD;
using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.Models.DeanRoom;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Repository
{
    public class ApplicantDirectionRepository : IApplicantDirectionRepository
    {
        public ObservableCollection<string> Directions { get; set; }
        public ObservableCollection<Enrollee> DirectionEnrollees { get; set; }
        ObservableCollection<Enrollee> _enrollees;
        public void GetDirections() 
        {
            ICollection<Faculty> faculties = new List<Faculty>();

            var files = Directory.GetFiles(FileServer.DeanRoomData, "*.json");
            if (files.Length > 0) 
                foreach (var file in files)
                {
                    var json = File.ReadAllText(file);
                    var faculty = JsonConvert.DeserializeObject<Faculty>(json);
                    faculties.Add(faculty);
                }

            foreach (var faculty in faculties)
                foreach (var levels in faculty.Levels)
                    foreach (var forms in levels.Forms)
                        foreach (var typeGroup in forms.TypeGroups)
                            foreach(var group in typeGroup.Groups)
                                Directions.Add(group.Direction);
        }
        public void GetEnrollees(string direction)
        {
            foreach (var enrollee in _enrollees)
                foreach (var directionName in enrollee.Directions)
                    if (directionName.NameDirection == direction)
                        DirectionEnrollees.Add(enrollee);
        }

        public ApplicantDirectionRepository()
        {
            Directions = new();
            DirectionEnrollees = new();
            _enrollees = new();
            InitializationEnrollees();
        }

        void InitializationEnrollees()
        {
            var files = Directory.GetFiles(FileServer.Enrollees, "*.json");
            if (files.Length > 0)
                foreach (var file in files)
                {
                    var json = File.ReadAllText(file);
                    var enrollee = JsonConvert.DeserializeObject<Enrollee>(json);
                    _enrollees.Add(enrollee);
                }
        }
    }
}