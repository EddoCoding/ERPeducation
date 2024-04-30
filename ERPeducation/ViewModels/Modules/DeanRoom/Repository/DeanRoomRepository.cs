using ERPeducation.Common.BD;
using ERPeducation.Models.DeanRoom;
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
        }  //Факультеты


        ObservableCollection<LvlOfTraining> _levels;
        public ObservableCollection<LvlOfTraining> Levels
        {
            get => _levels;
            set => this.RaiseAndSetIfChanged(ref _levels, value);
        }     //Уровни подготовки


        ObservableCollection<FormsOfTraining> _forms;
        public ObservableCollection<FormsOfTraining> Forms
        {
            get => _forms;
            set => this.RaiseAndSetIfChanged(ref _forms, value);
        }      //Формы подготовки


        ObservableCollection<TypeGroup> _types;
        public ObservableCollection<TypeGroup> Types
        {
            get => _types;
            set => this.RaiseAndSetIfChanged(ref _types, value);
        }      //Типы групп


        ObservableCollection<Group> _groups;
        public ObservableCollection<Group> Groups
        {
            get => _groups;
            set => this.RaiseAndSetIfChanged(ref _groups, value);
        }     //Учебные группы


        ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get => _students;
            set => this.RaiseAndSetIfChanged(ref _students, value);
        }   //Студенты

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


            return faculties;
        } //Десериализация факультетов -- чтобы можно было их выбрать изначально --

        public void CreateFaculty(Faculty faculty)
        {
            _faculties.Add(faculty);
            var data = new
            {
                Levels = _levels,
                Forms = _forms,
                Types = _types,
                Groups = _groups,
                Students = _students
            };


            //string json = JsonConvert.SerializeObject(data);
            //using(FileStream fs = new FileStream($"ыфв.json", FileMode.Create, FileAccess.Write))
            //{
            //    using(StreamWriter sw = new StreamWriter(fs))
            //    {
            //        sw.Write(json);
            //    }
            //}
        }
        public void DeleteFaculty(Faculty faculty) => _faculties.Remove(faculty);





        public void DeleteLevel(LvlOfTraining level) => _levels.Remove(level);
        public void DeleteForm(FormsOfTraining form) => _forms.Remove(form);
        public void DeleteTypeGroup(TypeGroup typeGroup) => _types.Remove(typeGroup);
        public void DeleteGroup(Group group) => _groups.Remove(group);
        public void DeleteStudent(Student student) => _students.Remove(student);




        void GetFaculty() { } //Получаем факультеты во ViewModel
        void GetLevels() { } //Получаем уровни во ViewModel
        // И так далее...
    }
}