using ERPeducation.Common.Command;
using ERPeducation.Interface;
using ERPeducation.Models.AdmissionCampaign;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class AdmissionCampaignViewModel
    {
        #region Свойства
        public ObservableCollection<Enrollee> Enrollees { get; set; }
        Enrollee selectedEnrollee;
        public Enrollee SelectedEnrollee
        {
            get => selectedEnrollee;
            set => selectedEnrollee = value;
        }
        #endregion
        #region Команды
        #endregion

        public string[] q { get; set; } = { "1", "2", "3", "4", "5" }; //УБРАТЬ ПОТОМ

        public AdmissionCampaignViewModel()
        {
            Enrollees = new ObservableCollection<Enrollee>()
            {
                new Enrollee("Викторова1", "Виктория1", "Викторовна1"),
                new Enrollee("Викторова2", "Виктория2", "Викторовна2"),
                new Enrollee("Викторова3", "Виктория3", "Викторовна3"),
                new Enrollee("Викторова4", "Виктория4", "Викторовна4")
            };
        }
    }
}