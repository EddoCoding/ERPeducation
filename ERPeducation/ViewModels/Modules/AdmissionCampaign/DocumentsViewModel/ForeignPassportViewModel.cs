using ERPeducation.Command;
using ERPeducation.Models.AdmissionCampaign.Documents;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class ForeignPassportViewModel
    {
        public ICommand command { get; set; }

        public ForeignPassportViewModel(EnrollePersonalInformationViewModel Main)
        {
            command = new RelayCommand(() =>
            {

            });
        }
    }
}
