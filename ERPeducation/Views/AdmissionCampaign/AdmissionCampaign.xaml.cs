﻿using ERPeducation.ViewModels.Modules.Administration;
using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using System.Windows.Controls;

namespace ERPeducation.Views.AdmissionCampaign
{
    public partial class AdmissionCampaign : UserControl
    {
        public AdmissionCampaign(AdmissionCampaignViewModel admissionCampaignViewModel)
        {
            InitializeComponent();
            DataContext = admissionCampaignViewModel;
        }
    }
}
