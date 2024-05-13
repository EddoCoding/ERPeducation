using ERPeducation.Common.BD;
using ERPeducation.Models;
using ERPeducation.Models.TrainingDivision;
using ERPeducation.ViewModels.Modules.TrainingDivision.Repository;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Reactive;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class SettingSyllabusViewModel : ReactiveObject
    {
        public Syllabus Syllabus { get; set; }
        public ObservableCollection<Semestr> Semesters { get; set; } = new();

        #region Команды
        public ReactiveCommand<Unit, Unit> AddSemestrCommand { get; set; }
        public ReactiveCommand<Semestr, Unit> DelSemestrCommand { get; set; }
        public ReactiveCommand<Semestr, Unit> AddDisciplineCommand { get; set; }
        public ReactiveCommand<Syllabus, Unit> SaveSyllabusCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Discipline, Unit> DelDisciplineCommand { get; set; }
        public ReactiveCommand<Unit, Unit> UpdateDataSemestrCommand { get; set; }
        public ReactiveCommand<Semestr, Unit> AddCourseworkCommand { get; set; }
        public ReactiveCommand<Coursework, Unit> DelCourseworkCommand { get; set; }
        #endregion

        Action _closeWindow;

        ISemestrRepository _semestrRepository = new SemestrRepository();
        public SettingSyllabusViewModel(Syllabus syllabus, Action closeWindow)
        {
            Syllabus = syllabus;
            _closeWindow = closeWindow;

            _semestrRepository.Semesters.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Semesters.Add(e.NewItems[0] as Semestr);
                else if (e.Action == NotifyCollectionChangedAction.Remove) Semesters.Remove(e.OldItems[0] as Semestr);
            };
            _semestrRepository.GetSemesters(syllabus);

            #region Инициализация команд
            AddSemestrCommand = ReactiveCommand.Create(AddSemestr);
            DelSemestrCommand = ReactiveCommand.Create<Semestr>(DelSemestr);
            AddDisciplineCommand = ReactiveCommand.Create<Semestr>(AddDiscipline);
            SaveSyllabusCommand = ReactiveCommand.Create<Syllabus>(SaveSettingSyllabus);
            CloseWindowCommand = ReactiveCommand.Create(Exit);
            DelDisciplineCommand = ReactiveCommand.Create<Discipline>(DelDiscipline);
            AddCourseworkCommand = ReactiveCommand.Create<Semestr>(AddCoursework);
            DelCourseworkCommand = ReactiveCommand.Create<Coursework>(DelCoursework);
            #endregion
        }
        #region Методы
        void Exit() => _closeWindow();
        void AddSemestr() => _semestrRepository.AddSemestr();
        void AddDiscipline(Semestr semestr) => _semestrRepository.AddDiscipline(semestr);
        void DelSemestr(Semestr semestr) => _semestrRepository.DelSemestr(semestr);
        void SaveSettingSyllabus(Syllabus syllabus)
        {
            syllabus.Semesters = Semesters;
            string json = JsonConvert.SerializeObject(syllabus, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            });
            File.WriteAllText(Path.Combine(FileServer.Syllabus, $"{syllabus.TitleSyllabus}.json"), json);
            _closeWindow();
        } // -- Убрать сериализацию в репозиторий --
        void DelDiscipline(Discipline discipline) => _semestrRepository.DelDiscipline(discipline);
        void AddCoursework(Semestr semestr) => _semestrRepository.AddCoursework(semestr);
        void DelCoursework(Coursework coursework) => _semestrRepository.DelCoursework(coursework);
        #endregion
    }
}