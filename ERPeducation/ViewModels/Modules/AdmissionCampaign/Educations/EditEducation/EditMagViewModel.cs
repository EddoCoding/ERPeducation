using ERPeducation.Models.AdmissionCampaign.Educations;
using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Educations.EditEducation
{
    public class EditMagViewModel
    {
        public EducationMag Mag { get; set; }

        Action closeWindow;

        public ReactiveCommand<EducationMag, Unit> SaveEducationCommand { get; set; }

        public EditMagViewModel(EducationBase education, Action closeWindow)
        {
            Mag = (EducationMag)education;
            this.closeWindow = closeWindow;

            SaveEducationCommand = ReactiveCommand.Create<EducationMag>(SaveEducation);
        }

        void SaveEducation(EducationMag education) => closeWindow();
    }
}
