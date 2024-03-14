using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;
using System.Text.Json.Serialization;

namespace ERPeducation.Common.Windows.AddUser
{
    public class UserViewModel : ReactiveObject
    {
        [Reactive] public string FullName { get; set; } = string.Empty;
        [Reactive] public string Identifier { get; set; } = string.Empty;

        [JsonIgnore] public ReactiveCommand<Unit, Unit> DeleteUserCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit, Unit> ChangeDataUserCommand { get; set; }

        public event Action<UserViewModel>? OnDelete;
        public event Action<UserViewModel>? OnChange;

        //ДОСТУПЫ К МОДУЛЯМ
        public bool RectorAccess { get; set; }
        public bool DeanRoomAccess { get; set; }
        public bool TrainingDivisionAccess { get; set; }
        public bool TeacherAccess { get; set; }
        public bool AdmissionCampaignAccess { get; set; }
        public bool AdministrationAccess { get; set; }

        public UserViewModel(string fullname, string identifier, bool rectorAccess, bool deanRoomAccess,
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

            InitializingCommands();
        }

        void InitializingCommands()
        {
            DeleteUserCommand = ReactiveCommand.Create(() =>
            {
                OnDelete?.Invoke(this);
            });

            ChangeDataUserCommand = ReactiveCommand.Create(() =>
            {
                OnChange?.Invoke(this);
            });
        }
    }
}
