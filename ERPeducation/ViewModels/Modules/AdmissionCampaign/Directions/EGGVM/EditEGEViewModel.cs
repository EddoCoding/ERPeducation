using ERPeducation.Models.AdmissionCampaign.Directions.TestEGG;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Repositories;
using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions.EGGVM
{
    public class EditEGEViewModel
    {
        public TestEGEBase EGE { get; set; }

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<EGE, Unit> EditEGECommand { get; set; }

        Action _closeWindow;

        public EditEGEViewModel(TestEGEBase ege, Action closeWindow)
        {
            _closeWindow = closeWindow;
            EGE = ege;

            EditEGECommand = ReactiveCommand.Create<EGE>(EditEGE);
        }

        void EditEGE(EGE ege) => _closeWindow();
    }
}
