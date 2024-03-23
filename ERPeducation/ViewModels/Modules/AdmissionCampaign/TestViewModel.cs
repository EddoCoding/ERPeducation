using ERPeducation.Common.Windows.WindowTest;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class TestViewModel : ReactiveObject
    {
        [Reactive] public string TextAddChange { get; set; } = "Добавить";

        [Reactive] public string SelectedObject { get; set; } = "Математика";
        [Reactive] public DateTime When { get; set; } = DateTime.Now;
        [Reactive] public string Where { get; set; } = "Аудитория 228";
        [Reactive] public bool SpecialConditions { get; set; } = true;

        public ReactiveCommand<Unit,Unit> ChangeTestCommand { get; set; }
        public ReactiveCommand<Unit,Unit> DeleteTestCommand { get; set; }
        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Unit,Unit> AddTestCommand { get; set; }

        public event Action<TestViewModel>? OnChange;
        public event Action<TestViewModel>? OnDelete;

        public void Change() => OnChange?.Invoke(this);
        public void Delete() => OnDelete?.Invoke(this);



        //КОНСТРУКТОР ДЛЯ ИЗМЕНЕНИЯ ОБЪЕКТА
        public TestViewModel(TestViewModel test, Action closeWindow)
        {
            TextAddChange = "Изменить";

            SelectedObject = test.SelectedObject;
            When = test.When;
            Where = test.Where;
            SpecialConditions = test.SpecialConditions;

            ChangeTestCommand = ReactiveCommand.Create(Change);
            DeleteTestCommand = ReactiveCommand.Create(Delete);
            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddTestCommand = ReactiveCommand.Create(() =>
            {
                test.SelectedObject = SelectedObject;
                test.When = When;
                test.Where = Where;
                test.SpecialConditions = SpecialConditions;

                closeWindow();
            });
        }

        //ОСНОВНОЙ КОНСТРУКТОР ДЛЯ НОВОГО ИСПЫТАНИЯ
        public TestViewModel(IDialogTest dialogTest, ObservableCollection<TestViewModel> test, Action closeWindow)
        {
            OnChange += test => dialogTest.GetTest(this);

            ChangeTestCommand = ReactiveCommand.Create(Change);
            DeleteTestCommand = ReactiveCommand.Create(Delete);
            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddTestCommand = ReactiveCommand.Create(() =>
            {
                test.Add(this);
                closeWindow();
            });
        }
    }
}
