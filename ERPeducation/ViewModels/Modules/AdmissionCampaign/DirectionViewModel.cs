using ERPeducation.Common.BD;
using ERPeducation.Common.Command;
using ERPeducation.Common.Windows.WindowDirection;
using ERPeducation.Common.Windows.WindowTest;
using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    [JsonObject]
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


        [JsonIgnore] public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit,Unit> ChangeDirectionCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit,Unit> DeleteDirectionCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit,Unit> AddDirectionCommand { get; set; }

        [JsonIgnore] public ReactiveCommand<Unit, Unit> AddTest { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit, Unit> SelectTemplateTest { get; set; }


         public event Action<DirectionViewModel>? OnChange;
         public event Action<DirectionViewModel>? OnDelete;
        
        IDialogDirection _dialogDirection;
        IDialogTest _dialogTest;
        public DirectionViewModel(ObservableCollection<DirectionViewModel> directions, Action closeWindow)
        {
            _dialogDirection = new DialogDirection();
            _dialogTest = new DialogTest();

            OnChange += changeDirection;

            LevelOfTraining = StaticData.GetLvlEducation();
            DirectionOfTraining = new ObservableCollection<string>();
            PreparationForm = new ObservableCollection<string>();

            Tests = new ObservableCollection<TestViewModel>();
            Tests.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (TestViewModel item in e.OldItems) item.OnDelete -= test => Tests.Remove(test);
                if (e.NewItems != null) foreach (TestViewModel item in e.NewItems) item.OnDelete += test => Tests.Remove(test);
            };

            ChangeDirectionCommand = ReactiveCommand.Create(() =>
            {
                OnChange?.Invoke(this);
            });
            DeleteDirectionCommand = ReactiveCommand.Create(() =>
            {
                OnDelete?.Invoke(this);
            });

            CloseWindowCommand = ReactiveCommand.Create(() =>
            {
                closeWindow();
            });
            AddDirectionCommand = ReactiveCommand.Create(() =>
            {
                directions.Add(this);
                closeWindow();
            });

            AddTest = ReactiveCommand.Create(() =>
            {
                _dialogTest.GetTest(Tests);
            });
            SelectTemplateTest = ReactiveCommand.Create(NotReady.Message);
        }

        void changeDirection(DirectionViewModel direction) => _dialogDirection.GetDirection(direction);
    }
}
