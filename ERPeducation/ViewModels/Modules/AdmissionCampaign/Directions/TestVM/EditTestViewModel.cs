using ERPeducation.Models.AdmissionCampaign;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions.TestVM
{
    public class EditTestViewModel
    {
        public Test Test { get; set; }

        public ReactiveCommand<Unit, Unit> EditTestCommand { get; set; }

        Action _closeWindow;

        public EditTestViewModel(Test test, Action closeWindow)
        {
            Test = test;
            _closeWindow = closeWindow;

            EditTestCommand = ReactiveCommand.Create(EditTest);
        }

        void EditTest() => _closeWindow();
    }
}
