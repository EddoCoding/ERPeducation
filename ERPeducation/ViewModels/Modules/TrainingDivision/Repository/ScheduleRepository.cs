using ERPeducation.Common.BD;
using ERPeducation.Models.TrainingDivision;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace ERPeducation.ViewModels.Modules.TrainingDivision.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        public ObservableCollection<Schedule> Schedules { get; set; } = new();
        public void GetSchedules()
        {
            var filesPath = Directory.GetFiles(FileServer.Schedule, "*.json");
            if(filesPath.Length > 0)
                foreach (var file in filesPath)
                {
                    var json = File.ReadAllText(file);
                    var schedule = JsonConvert.DeserializeObject<Schedule>(json);
                    Schedules.Add(schedule);
                }
        }
        public void AddSchedule(Schedule schedule)
        {
            Serialization(schedule);
            Schedules.Add(schedule);
        }
        public void DelSchedule(Schedule schedule)
        {
            if (File.Exists(Path.Combine(FileServer.Schedule, $"{schedule.TitleSchedule}.json")))
            {
                File.Delete(Path.Combine(FileServer.Schedule, $"{schedule.TitleSchedule}.json"));
                Schedules.Remove(schedule);
            }
        }

        void Serialization(Schedule schedule)
        {
            string json = JsonConvert.SerializeObject(schedule, Formatting.Indented);
            File.WriteAllText(Path.Combine(FileServer.Schedule, $"{schedule.TitleSchedule}.json"), json);
        }
    }
}