using ERPeducation.Interface;
using ERPeducation.Views.AdmissionCampaign.DocumentsView;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel
{
    public class DocumentsViewModel : INPC
    {
        #region Свойства
        public string[] Docs { get; set; } = { "Паспорт", "СНИЛС", "ИНН", "Военный билет", "Иностранный паспорт" };

        string valueComboBox = string.Empty;
        public string ValueComboBox
        {
            get => valueComboBox;
            set
            {
                valueComboBox = value;
                OnPropertyChanged(nameof(ValueComboBox));
                GetView();
            }
        }

        UserControl userControl;
        public UserControl UserControl
        {
            get => userControl;
            set
            {
                userControl = value;
                OnPropertyChanged(nameof(UserControl));
            }
        }
        #endregion

        public EnrollePersonalInformationViewModel enrolleeViewModel { get; set; }

        public DocumentsViewModel(EnrollePersonalInformationViewModel enrolleeViewModel)
        {
            this.enrolleeViewModel = enrolleeViewModel;
        }

        void GetView()
        {
            switch (ValueComboBox)
            {
                case "Паспорт":
                    UserControl = new PassportView(new PassportViewModel(enrolleeViewModel));
                    break;
                case "СНИЛС":
                    UserControl = new SnilsView();
                    break;
                case "ИНН":
                    UserControl = new InnView();
                    break;
                case "Военный билет":
                    UserControl = new MilitaryTicketView();
                    break;
                case "Иностранный паспорт":
                    UserControl = new ForeignPassportView();
                    break;
            }
        }
    }
}