using ERPeducation.Common.BD;
using ERPeducation.Models;
using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.Models.AdmissionCampaign.Direction;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions.TestVM;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Services;
using ERPeducation.Views.AdmissionCampaign;
using ERPeducation.Views.AdmissionCampaign.WindowDirections.WindowTests;
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
            Serialization(enrollee);
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

        public void OpenPageEditEnrollee(MainTabControl<MainTabItem> mainTabControls, Enrollee enrollee)
        {
            EditEnrolleePage editPage = new();
            editPage.DataContext = new EditEnrolleeViewModel(this, new EnrolleeDocumentService(), new EnrolleeRepository(), enrollee);
            mainTabControls.TabItem.Add(new MainTabItem("Изменение абитуриента", editPage));
        }

        public void OpenWindowInputResultTest(DirectionOfAdmission direction, Enrollee enrollee)
        {
            InputTestResultWindow inputTestResultWindow = new InputTestResultWindow();
            inputTestResultWindow.DataContext = new InputResultTestViewModel(this, direction, enrollee, inputTestResultWindow.Close);
            inputTestResultWindow.ShowDialog();
        }

        public void Serialization(Enrollee enrollee)
        {
            if (Directory.Exists(FileServer.Enrollees))
                using (StreamWriter file = File.CreateText(Path.Combine(FileServer.Enrollees, $"{enrollee.SurName}{enrollee.Name}{enrollee.MiddleName}.json")))
                {
                    file.Write(JsonConvert.SerializeObject(enrollee, jsonSetting));
                }
        }
    }
}