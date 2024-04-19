using ERPeducation.Common.Windows.Syllabus.WindowSettingSyllabus.WindowAddDiscipline;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class SemestrVM : ReactiveObject
    {
        public string Number { get; set; }
        public ObservableCollection<DisciplineVM> Disciplines { get; set; }

        public ReactiveCommand<Unit,Unit> AddDisciplineCommand { get; set; }
        public ReactiveCommand<DisciplineVM,Unit> DelDisciplineCommand { get; set; }


        IDiscipline _discipline;
        public SemestrVM(string number = default)
        {
            _discipline = new Discipline();
            Number = number;

            Disciplines = new ObservableCollection<DisciplineVM>();
            Disciplines.CollectionChanged += Hren;

            AddDisciplineCommand = ReactiveCommand.Create(AddDiscipline);
            DelDisciplineCommand = ReactiveCommand.Create<DisciplineVM>(DeleteDiscipline);
        }

        void AddDiscipline() => _discipline.AddDiscipline(Disciplines);
        void DeleteDiscipline(DisciplineVM discipline) => Disciplines.Remove(discipline);

        void Hren(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add) MessageBox.Show("Элемент Добавлен");
            if (e.Action == NotifyCollectionChangedAction.Remove) MessageBox.Show("Элемент удален");
        }
    }
}
