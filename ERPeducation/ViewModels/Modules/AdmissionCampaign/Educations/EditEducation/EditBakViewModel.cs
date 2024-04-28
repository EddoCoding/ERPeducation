using ERPeducation.Models.AdmissionCampaign.Educations;
using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Educations.EditEducation
{
    public class EditBakViewModel
    {
        public EducationBak Bak { get; set; }

        Action closeWindow;

        public ReactiveCommand<EducationBak, Unit> SaveEducationCommand { get; set; }

        public EditBakViewModel(EducationBase education, Action closeWindow)
        {
            Bak = (EducationBak)education;
            this.closeWindow = closeWindow;

            SaveEducationCommand = ReactiveCommand.Create<EducationBak>(SaveEducation);
        }

        void SaveEducation(EducationBak education) => closeWindow();
    }
}
