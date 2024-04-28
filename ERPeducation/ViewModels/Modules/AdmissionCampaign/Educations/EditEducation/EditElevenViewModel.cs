using ERPeducation.Models.AdmissionCampaign.Educations;
using ReactiveUI;
using System.Reactive;
using System;
using System.Windows.Shapes;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Educations.EditEducation
{
    public class EditElevenViewModel
    {
        public EducationEleven Eleven { get; set; }

        Action closeWindow;

        public ReactiveCommand<EducationEleven, Unit> SaveEducationCommand { get; set; }

        public EditElevenViewModel(EducationBase education, Action closeWindow)
        {
            Eleven = (EducationEleven)education;
            this.closeWindow = closeWindow;

            SaveEducationCommand = ReactiveCommand.Create<EducationEleven>(SaveEducation);
        }

        void SaveEducation(EducationEleven education) => closeWindow();
    }
}
