﻿using ERPeducation.Command;
using ERPeducation.Models.AdmissionCampaign.Documents;
using System.Windows;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class PassportViewModel
    {
        public ICommand command { get; set; }

        public string[] Gender { get; set; } = { "Муж", "Жен" };

        public PassportViewModel(EnrollePersonalInformationViewModel Main) 
        {
            command = new RelayCommand(() => 
            {
                MessageBox.Show("Проверка");
            });
        }
    }
}
