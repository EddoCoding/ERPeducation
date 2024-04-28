using ERPeducation.Models.AdmissionCampaign.Educations;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Educations.AddEducation
{
    public class SPOViewModel
    {
        public EducationSPO SPO { get; set; } = new();

        Action closeWindow;

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<EducationSPO, Unit> AddEducationCommand { get; set; }

        IEnrolleeRepository _repository;
        public SPOViewModel(IEnrolleeRepository repository, Action closeWindow)
        {
            _repository = repository;
            this.closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddEducationCommand = ReactiveCommand.Create<EducationSPO>(AddEducation);
        }

        void Exit() => closeWindow();
        void AddEducation(EducationSPO education)
        {
            _repository.CreateEducation(education);
            closeWindow();
        }
    }
}
