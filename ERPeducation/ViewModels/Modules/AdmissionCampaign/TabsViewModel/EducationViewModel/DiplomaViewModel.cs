using ERPeducation.Command;
using ERPeducation.Common.Interface;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Windows;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel
{
    public class DiplomaViewModel : ReactiveObject
    {
        #region Свойства контролов
        public string TypeEducation { get; set; }
        public bool IsBool { get; set; }
        public string NumberDiploma { get; set; }
        public int RegistrationNumber { get; set; }
        [Reactive] public DateTime DateOfIssue { get; set; }
        [Reactive] public bool IsPopup { get; set; }
        public string Qualification { get; set; }
        public string IssuedBy { get; set; }
        public string AdditionalNumberDiploma { get; set; }
        #endregion
        #region Команды
        public ICommand AddEducation { get; set; }
        public ICommand OpenClosePoPup { get; set; }
        #endregion

        EnrolleeEducationViewModel ViewModel;

        IEducationModelService _educationModelService1;

        public DiplomaViewModel(IEducationModelService educationModelService, string typeEducation, EnrolleeEducationViewModel enrolleeEducationViewModel)
        {
            _educationModelService1 = educationModelService;

            ViewModel = enrolleeEducationViewModel;

            TypeEducation = typeEducation;

            OpenClosePoPup = new RelayCommand(() => 
            {
                if (IsPopup == false) IsPopup = true;
                else IsPopup = false;
            });

            AddEducation = new RelayCommand(() => 
            {
                enrolleeEducationViewModel.Education.Add(_educationModelService1.GetModel(this));
                //Добавить выход
            });
        }
    }
}
