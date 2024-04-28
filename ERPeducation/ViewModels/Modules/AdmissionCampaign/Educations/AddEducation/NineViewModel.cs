using ERPeducation.Models.AdmissionCampaign.Educations;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Educations.AddEducation
{
    public class NineViewModel
    {
        public EducationNine Nine { get; set; } = new();

        Action closeWindow;

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<EducationNine, Unit> AddEducationCommand { get; set; }

        IEnrolleeRepository _repository;
        public NineViewModel(IEnrolleeRepository repository, Action closeWindow)
        {
            _repository = repository;
            this.closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddEducationCommand = ReactiveCommand.Create<EducationNine>(AddEducation);
        }

        void Exit() => closeWindow();
        void AddEducation(EducationNine education)
        {
            _repository.CreateEducation(education);
            closeWindow();
        }
    }
}
