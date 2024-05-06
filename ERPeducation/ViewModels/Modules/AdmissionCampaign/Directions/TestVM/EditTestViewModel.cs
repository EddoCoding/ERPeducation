using ERPeducation.Models.AdmissionCampaign.Directions.TestEGG;
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

        public EditTestViewModel(TestEGEBase test, Action closeWindow)
        {
            Test = (Test)test;
            _closeWindow = closeWindow;

            EditTestCommand = ReactiveCommand.Create(EditTest);
        }

        void EditTest() => _closeWindow();
    }
}
