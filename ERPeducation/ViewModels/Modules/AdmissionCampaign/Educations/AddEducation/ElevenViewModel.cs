using ERPeducation.Models.AdmissionCampaign.Educations;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Educations.AddEducation
{
    public class ElevenViewModel
    {
        public EducationEleven Eleven { get; set; } = new();

        Action closeWindow;

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<EducationEleven, Unit> AddEducationCommand { get; set; }

        IEnrolleeRepository _repository;
        public ElevenViewModel(IEnrolleeRepository repository, Action closeWindow)
        {
            _repository = repository;
            this.closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddEducationCommand = ReactiveCommand.Create<EducationEleven>(AddEducation);
        }

        void Exit() => closeWindow();
        void AddEducation(EducationEleven education)
        {
            _repository.CreateEducation(education);
            closeWindow();
        }
    }
}
