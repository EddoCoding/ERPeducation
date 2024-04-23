using ERPeducation.Common.Windows.WindowTest;
using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Old
{
    [JsonObject]
    public class TestViewModel : ReactiveObject
    {
        [Reactive] public string TextAddChange { get; set; } = "Добавить";

        [Reactive] public string SelectedObject { get; set; }
        [Reactive] public DateTime When { get; set; }
        [Reactive] public string Where { get; set; }
        [Reactive] public bool SpecialConditions { get; set; }

        [JsonIgnore] public ReactiveCommand<Unit, Unit> ChangeTestCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit, Unit> DeleteTestCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit, Unit> AddTestCommand { get; set; }

        public event Action<TestViewModel>? OnChange;
        public event Action<TestViewModel>? OnDelete;


        IDialogTest _dialogTest;
        public TestViewModel(ObservableCollection<TestViewModel> test, Action closeWindow)
        {
            _dialogTest = new DialogTest();

            OnChange += changeTest;

            ChangeTestCommand = ReactiveCommand.Create(() =>
            {
                OnChange?.Invoke(this);
            });
            DeleteTestCommand = ReactiveCommand.Create(() =>
            {
                OnDelete?.Invoke(this);
            });
            CloseWindowCommand = ReactiveCommand.Create(() =>
            {
                closeWindow();
            });
            AddTestCommand = ReactiveCommand.Create(() =>
            {
                test.Add(this);
                closeWindow();
            });
        }

        void changeTest(TestViewModel tests) => _dialogTest.GetTest(tests);
    }
}
