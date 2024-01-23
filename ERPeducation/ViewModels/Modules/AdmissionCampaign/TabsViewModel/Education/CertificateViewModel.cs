using ERPeducation.Common.Interface.DialogModel;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel
{
    public class CertificateViewModel : ReactiveObject
    {
        #region Свойства контролов
        public string TitileButton { get; set; } = "Добавить образование";

        public string TypeEducation { get; set; }
        public string TypeEducationDocument { get; set; }
        public bool IsBool { get; set; }
        public long NumberCertificate { get; set; }
        [Reactive] public DateTime DateOfIssue { get; set; }
        [Reactive] public bool IsPopup { get; set; }
        public string IssuedBy { get; set; }
        #endregion
        #region Команды
        public ReactiveCommand<Unit, Unit> OpenClosePoPup { get; set; }
        public ReactiveCommand<Unit, Unit> AddEducation { get; set; }
        #endregion

        IEducationModelService _modelService;

        public CertificateViewModel(IEducationModelService modelService, string typeEducation, 
            EnrolleeEducationViewModel enrolleEducationViewModel, Action closeWindow) 
        {
            _modelService = modelService;

            TypeEducation = typeEducation;
            TypeEducationDocument = typeEducation;

            OpenClosePoPup = ReactiveCommand.Create(() => 
            {
                if (IsPopup == false) IsPopup = true;
                else IsPopup = false;
            });

            AddEducation = ReactiveCommand.Create(() =>
            {
                enrolleEducationViewModel.Education.Add(_modelService.GetModel(this));
                closeWindow();
            });
        }
    }
}
