using ERPeducation.Models.AdmissionCampaign.Educations;
using ReactiveUI;
using System.Reactive;
using System;
using System.Windows.Interop;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Educations.EditEducation
{
    public class EditAspViewModel
    {
        public EducationAsp Asp { get; set; }

        Action closeWindow;

        public ReactiveCommand<EducationAsp, Unit> SaveEducationCommand { get; set; }

        public EditAspViewModel(EducationBase education, Action closeWindow)
        {
            Asp = (EducationAsp)education;
            this.closeWindow = closeWindow;

            SaveEducationCommand = ReactiveCommand.Create<EducationAsp>(SaveEducation);
        }

        void SaveEducation(EducationAsp education) => closeWindow();
    }
}
