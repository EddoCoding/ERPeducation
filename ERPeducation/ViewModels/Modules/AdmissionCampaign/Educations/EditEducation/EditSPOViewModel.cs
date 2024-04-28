using ERPeducation.Models.AdmissionCampaign.Educations;
using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Educations.EditEducation
{
    public class EditSPOViewModel
    {
        public EducationSPO SPO { get; set; }

        Action closeWindow;

        public ReactiveCommand<EducationSPO, Unit> SaveEducationCommand { get; set; }

        public EditSPOViewModel(EducationBase education, Action closeWindow)
        {
            SPO = (EducationSPO)education;
            this.closeWindow = closeWindow;

            SaveEducationCommand = ReactiveCommand.Create<EducationSPO>(SaveEducation);
        }

        void SaveEducation(EducationSPO education) => closeWindow();
    }
}
