using ERPeducation.Models.AdmissionCampaign.Educations;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Educations.AddEducation
{
    public class MagViewModel
    {
        public EducationMag Mag { get; set; } = new();

        Action closeWindow;

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<EducationMag, Unit> AddEducationCommand { get; set; }

        IEnrolleeRepository _repository;
        public MagViewModel(IEnrolleeRepository repository, Action closeWindow)
        {
            _repository = repository;
            this.closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddEducationCommand = ReactiveCommand.Create<EducationMag>(AddEducation);
        }

        void Exit() => closeWindow();
        void AddEducation(EducationMag education)
        {
            _repository.CreateEducation(education);
            closeWindow();
        }
    }
}
