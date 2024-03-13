using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ReactiveUI;
using System;
using System.Reactive;
using System.Text.Json.Serialization;
using System.Windows;

namespace ERPeducation.Models
{
    public class UserModel : ReactiveObject
    {
        public string FullName { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;

        [JsonIgnore] public ReactiveCommand<Unit,Unit> Delete { get; set; }

        public event Action<UserModel>? OnDelete;

        //ДОСТУПЫ К МОДУЛЯМ
        public bool RectorAccess { get; set; }
        public bool DeanRoomAccess { get; set; }
        public bool TrainingDivisionAccess { get; set; }
        public bool TeacherAccess { get; set; }
        public bool AdmissionCampaignAccess { get; set; }
        public bool AdministrationAccess { get; set; }

        public UserModel(string fullname, string identifier, bool rectorAccess, bool deanRoomAccess, 
            bool trainingDivisionAccess, bool teacherAccess, bool admissionCampaignAccess, bool administrationAccess)
        {
            FullName = fullname;
            Identifier = identifier;

            RectorAccess = rectorAccess;
            DeanRoomAccess = deanRoomAccess;
            TrainingDivisionAccess = trainingDivisionAccess;
            TeacherAccess = teacherAccess;
            AdmissionCampaignAccess = admissionCampaignAccess;
            AdministrationAccess = administrationAccess;

            Delete = ReactiveCommand.Create(() =>
            {
                OnDelete?.Invoke(this);
            });
        }
    }
}
