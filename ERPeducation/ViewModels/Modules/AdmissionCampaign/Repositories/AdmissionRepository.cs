using ERPeducation.Common.BD;
using ERPeducation.Models;
using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Services;
using Newtonsoft.Json;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.IO;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class AdmissionRepository : ReactiveObject, IAdmissionRepository
    {
        JsonSerializerSettings jsonSetting = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All,
            Formatting = Formatting.Indented
        };
        
        ObservableCollection<Enrollee> _enrollees;
        public ObservableCollection<Enrollee> Enrollees
        {
            get => _enrollees;
            set => this.RaiseAndSetIfChanged(ref _enrollees, value);
        }

        public AdmissionRepository() => Enrollees = new ObservableCollection<Enrollee>();

        public void GetEnrollees()
        {
            Enrollees.Clear();
            if (Directory.Exists(FileServer.Enrollees))
            {
                string[] jsonFiles = Directory.GetFiles(FileServer.Enrollees, "*.json");
                foreach(var file in jsonFiles)
                {
                    using(StreamReader reader = new StreamReader(file))
                    {
                        var enrollee = JsonConvert.DeserializeObject<Enrollee>(reader.ReadToEnd(), jsonSetting);
                        _enrollees.Add(enrollee);
                    }
                }
            }
        }
        public void CreateEnrollee(Enrollee enrollee)
        {
            if(Directory.Exists(FileServer.Enrollees))
                using (StreamWriter file = File.CreateText(Path.Combine(FileServer.Enrollees, $"{enrollee.SurName}{enrollee.Name}{enrollee.MiddleName}.json")))
                {
                    file.Write(JsonConvert.SerializeObject(enrollee, jsonSetting));
                }
            _enrollees.Add(enrollee);
        }
        public void DelEnrolle(Enrollee enrollee)
        {
            if (File.Exists(Path.Combine(FileServer.Enrollees, $"{enrollee.SurName}{enrollee.Name}{enrollee.MiddleName}.json")))
                File.Delete(Path.Combine(FileServer.Enrollees, $"{enrollee.SurName}{enrollee.Name}{enrollee.MiddleName}.json"));
            _enrollees.Remove(enrollee);
        }

        public void OpenPageAddEnrollee(MainTabControl<MainTabItem> mainTabControls)
        {
            AddEnrolleePage page = new();
            page.DataContext = new AddEnrolleeViewModel(this, new EnrolleeDocumentService(), new EnrolleeRepository());
            mainTabControls.TabItem.Add(new MainTabItem("Добавление абитуриента", page));
        }

        public void OpenWindowInputResultTest()
        {

        }

    }
}