using ERPeducation.Models.AdmissionCampaign.Directions.TestEGG;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Repositories;
using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions.EGGVM
{
    public class EditEGEViewModel
    {
        public EGE EGE { get; set; }

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<EGE, Unit> EditEGECommand { get; set; }

        Action _closeWindow;

        public EditEGEViewModel(EGE egg, Action closeWindow)
        {
            _closeWindow = closeWindow;

            EditEGECommand = ReactiveCommand.Create<EGE>(EditEGG);
        }

        void EditEGG(EGE egg) => _closeWindow();
    }
}
