using ERPeducation.Common.BD;
using ERPeducation.Models;
using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class AdmissionRepository : IAdmissionRepository
    {
        public ICollection<Enrollee> Enrollees { get; set; } = new List<Enrollee>();

        public ICollection<Enrollee> GetEnrollees()
        {
            Enrollees.Clear();
            if (Directory.Exists(FileServer.Enrollees))
            {
                string[] jsonFiles = Directory.GetFiles(FileServer.Enrollees, "*.json");
                foreach(var file in jsonFiles)
                {
                    using(StreamReader reader = new StreamReader(file))
                    {
                        Enrollees.Add(JsonConvert.DeserializeObject<Enrollee>(reader.ReadToEnd()));
                    }
                }
            }
            return Enrollees;
        }
        public void OpenPageAddEnrollee(MainTabControl<MainTabItem> mainTabControls, ObservableCollection<Enrollee> enrollees)
        {
            AddEnrolleePage page = new();
            page.DataContext = new AddEnrolleeViewModel(this, new EnrolleeDocumentService(), new EnrolleeRepository(), enrollees);
            mainTabControls.TabItem.Add(new MainTabItem("Добавление абитуриента", page));
        }

        int i = 0;
        public void CreateEnrollee()
        {
            var jsonSetting = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };

            if (Directory.Exists(FileServer.Enrollees))
                using (StreamWriter file = File.CreateText(Path.Combine(FileServer.Enrollees, $"{i}.json")))
                {
                    file.Write(JsonConvert.SerializeObject(new Enrollee(), jsonSetting));
                }
        }
    }
}