using ERPeducation.Command;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class SnilsViewModel
    {
        public ICommand command { get; set; }

        public SnilsViewModel(EnrollePersonalInformationViewModel Main)
        {
            command = new RelayCommand(() =>
            {
                
            });
        }
    }
}
