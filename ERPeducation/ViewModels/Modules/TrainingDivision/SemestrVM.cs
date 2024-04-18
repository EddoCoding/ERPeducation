using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.TrainingDivision
{
    public class SemestrVM
    {
        public string Number { get; set; }
        public ObservableCollection<DisciplineVM> Disciplines { get; set; }

        public ReactiveCommand<Unit,Unit> AddDisciplineCommand { get; set; }

        public SemestrVM(string number = default)
        {
            Number = number;

            AddDisciplineCommand = ReactiveCommand.Create(AddDiscipline);

            Disciplines = new ObservableCollection<DisciplineVM>();
        }

        void AddDiscipline() => Disciplines.Add(new DisciplineVM("Базы данных", 999, 2000, "Зачет"));
    }
}
