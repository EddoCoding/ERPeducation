using ERPeducation.Command;
using System.Windows.Input;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class PassportViewModel : DocumentBase
    {




        public ICommand command { get; set; }

        public PassportViewModel(EnrollePersonalInformationViewModel Main) 
        {
            command = new RelayCommand(() => 
            {
                Main.Documents.Add(new DocumentBase());
                Main.Documents.Add(new PassportViewModel(new EnrollePersonalInformationViewModel())); //Нужно сделать model для всех документов
            });
        }
    }
}
