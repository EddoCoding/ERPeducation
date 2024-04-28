using ERPeducation.Models.AdmissionCampaign.Educations;
using ReactiveUI;
using System.Reactive;
using System;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Educations.EditEducation
{
    public class EditNineViewModel
    {
        public EducationNine Nine { get; set; }

        Action closeWindow;

        public ReactiveCommand<EducationNine, Unit> SaveEducationCommand { get; set; }

        public EditNineViewModel(EducationBase education, Action closeWindow)
        {
            Nine = (EducationNine)education;
            this.closeWindow = closeWindow;

            SaveEducationCommand = ReactiveCommand.Create<EducationNine>(SaveEducation);
        }

        void SaveEducation(EducationNine education) => closeWindow();
    }
}
