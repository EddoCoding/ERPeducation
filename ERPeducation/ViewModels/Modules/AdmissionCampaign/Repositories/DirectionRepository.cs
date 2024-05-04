using ERPeducation.Common.BD;
using ERPeducation.Models.DeanRoom;
using Newtonsoft.Json;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.IO;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Repositories
{
    public class DirectionRepository : ReactiveObject, IDirectionRepository
    {
        ObservableCollection<Faculty> _faculties;                                      
        public ObservableCollection<Faculty> Faculties
        {
            get => _faculties;
            set => this.RaiseAndSetIfChanged(ref _faculties, value);
        }

        ObservableCollection<LvlOfTraining> _levels;
        public ObservableCollection<LvlOfTraining> Levels
        {
            get => _levels;
            set => this.RaiseAndSetIfChanged(ref _levels, value);
        }

        ObservableCollection<FormsOfTraining> _forms;
        public ObservableCollection<FormsOfTraining> Forms
        {
            get => _forms;
            set => this.RaiseAndSetIfChanged(ref _forms, value);
        }

        ObservableCollection<TypeGroup> _types;
        public ObservableCollection<TypeGroup> Types
        {
            get => _types;
            set => this.RaiseAndSetIfChanged(ref _types, value);
        }

        ObservableCollection<Group> _groups;
        public ObservableCollection<Group> Groups
        {
            get => _groups;
            set => this.RaiseAndSetIfChanged(ref _groups, value);
        }

        public DirectionRepository()
        {
            Faculties = new ObservableCollection<Faculty>();
            Levels = new ObservableCollection<LvlOfTraining>();
            Forms = new ObservableCollection<FormsOfTraining>();
            Types = new ObservableCollection<TypeGroup>();
            Groups = new ObservableCollection<Group>();
        }

        public void GetFaculties()
        {
            var files = Directory.GetFiles(FileServer.DeanRoomData, "*.json");
            if (files.Length > 0)
                foreach (var file in files)
                {
                    var json = File.ReadAllText(file);
                    var faculty = JsonConvert.DeserializeObject<Faculty>(json);
                    _faculties.Add(faculty);
                }
        }

        public void GetLevels(Faculty faculty)
        {
            foreach(var level in faculty.Levels)
                _levels.Add(level);
        }
        public void GetForms(LvlOfTraining level)
        {
            foreach (var form in level.Forms)
                _forms.Add(form);
        }
        public void GetTypes(FormsOfTraining form)
        {
            foreach(var typeGroup in form.TypeGroups)
                _types.Add(typeGroup);
        }
        public void GetGroups(TypeGroup typeGroup)
        {
            foreach(var group in typeGroup.Groups)
                _groups.Add(group);
        }
    }
}