using ERPeducation.Common.BD;
using ERPeducation.Models;
using ERPeducation.Models.DeanRoom;
using ERPeducation.Models.TrainingDivision;
using Newtonsoft.Json;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Repository
{
    public class DeanRoomRepository : ReactiveObject, IDeanRoomRepository
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


        ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get => _students;
            set => this.RaiseAndSetIfChanged(ref _students, value);
        }           

        public DeanRoomRepository() 
        {
            Faculties = new ObservableCollection<Faculty>();
            Levels = new ObservableCollection<LvlOfTraining>();
            Forms = new ObservableCollection<FormsOfTraining>();
            Types = new ObservableCollection<TypeGroup>();
            Groups = new ObservableCollection<Group>();
            Students = new ObservableCollection<Student>();
        }

        public ICollection<Faculty> GetJsonFaculty()
        {
            ICollection<Faculty> faculties = new List<Faculty>();

            var files = Directory.GetFiles(FileServer.DeanRoomData, "*.json");
            if (files.Length > 0)
                foreach (var file in files)
                {
                    var json = File.ReadAllText(file);
                    var faculty = JsonConvert.DeserializeObject<Faculty>(json);
                    faculties.Add(faculty);
                    _faculties.Add(faculty);
                }

            return faculties;
        }

        public IEnumerable<Syllabus> GetSyllabus() 
        {
            ICollection<Syllabus> syllabus = new List<Syllabus>();
            var files = Directory.GetFiles(FileServer.Syllabus, "*.json");
            if (files.Length > 0)
                foreach (var file in files)
                {
                    var json = File.ReadAllText(file);
                    var syllabusItem = JsonConvert.DeserializeObject<Syllabus>(json);
                    syllabus.Add(syllabusItem);
                }
            return syllabus;
        }
        public IEnumerable<Schedule> GetSchedule()
        {
            ICollection<Schedule> schedule = new List<Schedule>();
            var files = Directory.GetFiles(FileServer.Schedule, "*.json");
            if (files.Length > 0)
                foreach (var file in files)
                {
                    var json = File.ReadAllText(file);
                    var scheduleItem = JsonConvert.DeserializeObject<Schedule>(json);
                    schedule.Add(scheduleItem);
                }
            return schedule;
        }

        public void CreateFaculty(Faculty faculty)
        {
            Serialization(faculty);
            _faculties.Add(faculty);
        }
        public void EditFaculty(Faculty oldNameFaculty, Faculty newNameFaculty)
        {
            Serialization(newNameFaculty);
            _faculties.Add(newNameFaculty);

            File.Delete(Path.Combine(FileServer.DeanRoomData, $"{oldNameFaculty.NameFaculty}.json"));
            _faculties.Remove(oldNameFaculty);
        }
        public void DeleteFaculty(Faculty faculty)
        {
            if (File.Exists(Path.Combine(FileServer.DeanRoomData, $"{faculty.NameFaculty}.json")))
                File.Delete(Path.Combine(FileServer.DeanRoomData, $"{faculty.NameFaculty}.json"));

            _faculties.Remove(faculty);
        }


        public void CreateLevel(LvlOfTraining level, Faculty faculty)
        {
            faculty.Levels.Add(level);
            Serialization(faculty);
            _levels.Add(level);
        }
        public void EditLevel(LvlOfTraining oldNamelevel, LvlOfTraining newNamelevel, Faculty faculty)
        {
            faculty.Levels.Remove(oldNamelevel);
            faculty.Levels.Add(newNamelevel);
            _levels.Add(newNamelevel);
            Serialization(faculty);
            _levels.Remove(oldNamelevel);
        }
        public void DeleteLevel(LvlOfTraining level, Faculty faculty)
        {
            if(faculty != null)
            {
                faculty.Levels.Remove(level);
                Serialization(faculty);
            }
            _levels.Remove(level);
        }

        public void CreateForm(FormsOfTraining form, LvlOfTraining level, Faculty faculty)
        {
            foreach(var levelItem in faculty.Levels)
                if (levelItem.NameLevel == level.NameLevel)
                    levelItem.Forms.Add(form);

            Serialization(faculty);
            _forms.Add(form);
        }
        public void EditForm(FormsOfTraining oldNameForm, FormsOfTraining newNameForm, LvlOfTraining level, Faculty faculty)
        {
            level.Forms.Remove(oldNameForm);
            level.Forms.Add(newNameForm);
            _forms.Add(newNameForm);
            Serialization(faculty);
            _forms.Remove(oldNameForm);
        }
        public void DeleteForm(FormsOfTraining form, LvlOfTraining level, Faculty faculty)
        {
            if(level != null)
            {
                level.Forms.Remove(form);
                Serialization(faculty);
            }                                                                         
            _forms.Remove(form);                                                                               
        }

        public void CreateTypeGroup(TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty)
        {
            foreach (var levelItem in faculty.Levels)
                if (levelItem.NameLevel == level.NameLevel)
                    foreach(var formItem in levelItem.Forms)
                        if(formItem.NameForm == form.NameForm)
                            formItem.TypeGroups.Add(typeGroup);

            Serialization(faculty);
            _types.Add(typeGroup);
        }
        public void EditTypeGroup(TypeGroup oldNameTypeGroup, TypeGroup newNameTypeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty)
        {
            form.TypeGroups.Remove(oldNameTypeGroup);
            form.TypeGroups.Add(newNameTypeGroup);
            _types.Add(newNameTypeGroup);
            Serialization(faculty);
            _types.Remove(oldNameTypeGroup);
        }
        public void DeleteTypeGroup(TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty)
        {
            if(form != null)
            {
                form.TypeGroups.Remove(typeGroup);
                Serialization(faculty);
            }
            _types.Remove(typeGroup);
        }

        public void CreateGroup(Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty)
        {
            foreach(var levelItem in faculty.Levels)
                if (levelItem.NameLevel == level.NameLevel)
                    foreach(var formItem in levelItem.Forms)
                        if (formItem.NameForm == form.NameForm)
                            foreach(var typeGroupItem in formItem.TypeGroups)
                                if(typeGroupItem.NameType == typeGroup.NameType)
                                    typeGroup.Groups.Add(group);

            Serialization(faculty);
            _groups.Add(group);
        }
        public void EditGroup(Group oldNameGroup, Group newNameGroup, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty)
        {
            typeGroup.Groups.Remove(oldNameGroup);
            typeGroup.Groups.Add(newNameGroup);
            _groups.Add(newNameGroup);
            Serialization(faculty);
            _groups.Remove(oldNameGroup);
        }
        public void DeleteGroup(Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty)
        {
            if(typeGroup != null)
            {
                typeGroup.Groups.Remove(group);
                Serialization(faculty);
            }
            _groups.Remove(group);
        }

        public void CreateStudent(Student student, Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty)
        {
            foreach (var levelItem in faculty.Levels)
                if (levelItem.NameLevel == level.NameLevel)
                    foreach (var formItem in levelItem.Forms)
                        if (formItem.NameForm == form.NameForm)
                            foreach (var typeGroupItem in formItem.TypeGroups)
                                if (typeGroupItem.NameType == typeGroup.NameType)
                                    foreach(var groupItem in typeGroupItem.Groups)
                                        if(groupItem.NameGroup == group.NameGroup)
                                            group.Students.Add(student);

            Serialization(faculty);
            _students.Add(student);
        }
        public void EditStudent(Student oldStudent, Student newStudent, Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty)
        {
            group.Students.Remove(oldStudent);
            group.Students.Add(newStudent);
            _students.Add(newStudent);
            Serialization(faculty);
            _students.Remove(oldStudent);
        }
        public void DeleteStudent(Student student, Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty)
        {
            if (group != null)
            {
                group.Students.Remove(student);
                Serialization(faculty);
            }
            _students.Remove(student);
        }

        public void SelectedFaculty(Faculty faculty)
        {
            _levels.Clear();
            foreach(var level in faculty.Levels)
                _levels.Add(level);
        }
        public void SelectedLevel(LvlOfTraining level)
        {
            _forms.Clear();
            foreach(var form in level.Forms)
                _forms.Add(form);
        }
        public void SelectedForm(FormsOfTraining form)
        {
            _types.Clear();
            foreach(var typeGroup in form.TypeGroups)
                _types.Add(typeGroup);
        }
        public void SelectedTypeGroup(TypeGroup typeGroup)
        {
            _groups.Clear();
            foreach(var group in typeGroup.Groups)
                _groups.Add(group);
        }
        public void SelectedGroup(Group group)
        {
            _students.Clear();
            foreach(var student in group.Students)
                _students.Add(student);
        }

        void Serialization(Faculty faculty)
        {
            string json = JsonConvert.SerializeObject(faculty, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            });
            File.WriteAllText(Path.Combine(FileServer.DeanRoomData, $"{faculty.NameFaculty}.json"), json);
        }
    }
}