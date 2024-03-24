using ERPeducation.Common.BD;
using ERPeducation.Common.Command;
using ERPeducation.Common.Windows.WindowDirection;
using ERPeducation.Common.Windows.WindowTest;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class DirectionViewModel : ReactiveObject
    {
        [Reactive] public string TextAddChange { get; set; } = "Добавить";

        [Reactive] public ObservableCollection<string> LevelOfTraining { get; set; }
        [Reactive] public ObservableCollection<string> DirectionOfTraining { get; set; }
        [Reactive] public ObservableCollection<string> PreparationForm { get; set; }


        string selectedLvl;
        public string SelectedLvl
        {
            get => selectedLvl;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedLvl, value);
                DirectionOfTraining = StaticData.GetDirectionEducation(SelectedLvl);
            }
        }

        string selectedDirection;
        public string SelectedDirection
        {
            get => selectedDirection;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedDirection, value);
                PreparationForm = StaticData.GetFormEducation(SelectedDirection);
            }
        }

        [Reactive] public string SelectedForms { get; set; }


        public ObservableCollection<TestViewModel> Tests { get; set; }

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Unit,Unit> ChangeDirectionCommand { get; set; }
        public ReactiveCommand<Unit,Unit> DeleteDirectionCommand { get; set; }
        public ReactiveCommand<Unit,Unit> AddDirectionCommand { get; set; }

        public ReactiveCommand<Unit, Unit> AddTest { get; set; }
        public ReactiveCommand<Unit, Unit> SelectTemplateTest { get; set; }


        public Action<DirectionViewModel>? OnChange;
        public Action<DirectionViewModel>? OnDelete;

        public void Change() => OnChange?.Invoke(this);
        public void Delete() => OnDelete?.Invoke(this);


        //КОНСТРУКТОР ДЛЯ ИЗМЕНЕНИЯ ОБЪЕКТА
        public DirectionViewModel(DirectionViewModel directions, Action closeWindow)
        {
            TextAddChange = "Изменить";

            SelectedLvl = directions.SelectedLvl;
            SelectedDirection = directions.SelectedDirection;
            SelectedForms = directions.SelectedForms;
            Tests = directions.Tests;

            ChangeDirectionCommand = ReactiveCommand.Create(Change);
            DeleteDirectionCommand = ReactiveCommand.Create(Delete);
            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDirectionCommand = ReactiveCommand.Create(() =>
            {
                directions.SelectedLvl = SelectedLvl;
                directions.SelectedDirection = SelectedDirection;
                directions.SelectedForms = SelectedForms;

                closeWindow();
            });
        }

        //ОСНОВНОЙ КОНСТРУКТОР ДЛЯ НОВОГО НАПРАВЛЕНИЯ
        public DirectionViewModel(IDialogDirection dialogdirection, IDialogTest dialogTest, ObservableCollection<DirectionViewModel> directions, Action closeWindow)
        {
            OnChange += direction => dialogdirection.GetDirection(direction);

            LevelOfTraining = StaticData.GetLvlEducation();
            DirectionOfTraining = new ObservableCollection<string>();
            PreparationForm = new ObservableCollection<string>();

            Tests = new ObservableCollection<TestViewModel>();
            Tests.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (TestViewModel item in e.OldItems) item.OnDelete -= test => Tests.Remove(test);
                if (e.NewItems != null) foreach (TestViewModel item in e.NewItems) item.OnDelete += test => Tests.Remove(test);
            };

            ChangeDirectionCommand = ReactiveCommand.Create(Change);
            DeleteDirectionCommand = ReactiveCommand.Create(Delete);
            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDirectionCommand = ReactiveCommand.Create(() =>
            {
                directions.Add(this);
                closeWindow();
            });

            AddTest = ReactiveCommand.Create(() =>
            {
                dialogTest.GetTest(Tests);
            });
            SelectTemplateTest = ReactiveCommand.Create(NotReady.Message);
        }
    }
}
