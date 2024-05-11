using ERPeducation.Common.BD;
using ERPeducation.Models;
using ERPeducation.ViewModels.Modules.TrainingDivision.Repository;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class SettingSyllabusViewModel : ReactiveObject
    {
        public Syllabus Syllabus { get; set; }
        public ObservableCollection<Semestr> Semesters { get; set; } = new();

        #region Команды
        public ReactiveCommand<Unit, Unit> AddSemestrCommand { get; set; }
        public ReactiveCommand<Semestr, Unit> DelSemestrCommand { get; set; }
        public ReactiveCommand<Syllabus, Unit> SaveSyllabusCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CloseWindowCommand{ get; set; }
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

            AddSemestrCommand = ReactiveCommand.Create(AddSemestr);
            DelSemestrCommand = ReactiveCommand.Create<Semestr>(DelSemestr);
            SaveSyllabusCommand = ReactiveCommand.Create<Syllabus>(SaveSettingSyllabus);
            CloseWindowCommand = ReactiveCommand.Create(Exit);
        }

        #region Методы
        void Exit() => _closeWindow();
        void AddSemestr() => _semestrRepository.AddSemestr();
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
        #endregion
    }
}