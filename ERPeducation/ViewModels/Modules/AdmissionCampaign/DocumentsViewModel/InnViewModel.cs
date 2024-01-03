using ERPeducation.Command;
using ERPeducation.Models.AdmissionCampaign.Documents;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class InnViewModel
    {
        public ICommand command { get; set; }

        public InnViewModel(EnrollePersonalInformationViewModel Main)
        {
            command = new RelayCommand(() =>
            {

            });
        }
    }
}
