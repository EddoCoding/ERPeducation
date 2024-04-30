using ERPeducation.Models.DeanRoom;
using ReactiveUI;
using System.Collections.ObjectModel;

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


        ObservableCollection<string> _levels;
        public ObservableCollection<string> Levels
        {
            get => _levels;
            set => this.RaiseAndSetIfChanged(ref _levels, value);
        }     //Уровни подготовки


        ObservableCollection<string> _forms;
        public ObservableCollection<string> Forms
        {
            get => _forms;
            set => this.RaiseAndSetIfChanged(ref _forms, value);
        }      //Формы подготовки


        ObservableCollection<string> _types;
        public ObservableCollection<string> Types
        {
            get => _types;
            set => this.RaiseAndSetIfChanged(ref _types, value);
        }      //Типы групп


        ObservableCollection<string> _groups;
        public ObservableCollection<string> Groups
        {
            get => _groups;
            set => this.RaiseAndSetIfChanged(ref _groups, value);
        }     //Учебные группы


        ObservableCollection<string> _students;
        public ObservableCollection<string> Students
        {
            get => _students;
            set => this.RaiseAndSetIfChanged(ref _students, value);
        }   //Студенты

        public DeanRoomRepository() 
        {
            Faculties = new ObservableCollection<Faculty>();
            Levels = new ObservableCollection<string>();
            Forms = new ObservableCollection<string>();
            Types = new ObservableCollection<string>();
            Groups = new ObservableCollection<string>();
            Students = new ObservableCollection<string>();
        }

        public void CreateFaculty(Faculty faculty) => _faculties.Add(faculty);
        public void DeleteFaculty(Faculty faculty) => _faculties.Remove(faculty);

        void GetJsonFaculty() { } // _faculties = Десериализация файлов факультетов
        void GetFaculty() { } //Получаем факультеты во ViewModel
        void GetLevels() { } //Получаем уровни во ViewModel
        // И так далее...
    }
}