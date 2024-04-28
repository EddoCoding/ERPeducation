using ERPeducation.Models.AdmissionCampaign.Educations;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Educations.AddEducation
{
    public class AspViewModel
    {
        public EducationAsp Asp { get; set; } = new();

        Action closeWindow;

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<EducationAsp, Unit> AddEducationCommand { get; set; }

        IEnrolleeRepository _repository;
        public AspViewModel(IEnrolleeRepository repository, Action closeWindow)
        {
            _repository = repository;
            this.closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddEducationCommand = ReactiveCommand.Create<EducationAsp>(AddEducation);
        }

        void Exit() => closeWindow();
        void AddEducation(EducationAsp education)
        {
            _repository.CreateEducation(education);
            closeWindow();
        }
    }
}
