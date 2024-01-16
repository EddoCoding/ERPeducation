using ERPeducation.Command;
using ERPeducation.Common.Interface;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel
{
    public class CertificateViewModel : ReactiveObject
    {
        #region Свойства контролов
        public string TypeEducation { get; set; }
        public bool IsBool { get; set; }
        public long NumberCertificate { get; set; }
        [Reactive] public DateTime DateOfIssue { get; set; }
        [Reactive] public bool IsPopup { get; set; }
        public string IssuedBy { get; set; }
        #endregion
        #region Команды
        public ICommand OpenClosePoPup { get; set; }
        public ICommand AddEducation { get; set; }
        #endregion

        IEducationModelService _modelService;

        public CertificateViewModel(IEducationModelService modelService, string typeEducation, EnrolleeEducationViewModel enrolleEducationViewModel) 
        {
            _modelService = modelService;

            TypeEducation = typeEducation;

            OpenClosePoPup = new RelayCommand(() => 
            {
                if (IsPopup == false) IsPopup = true;
                else IsPopup = false;
            });

            AddEducation = new RelayCommand(() => 
            {
                enrolleEducationViewModel.Education.Add(_modelService.GetModel(this));
                //Добавить выход
            });
        }

        public string Jopa;
    }
}
