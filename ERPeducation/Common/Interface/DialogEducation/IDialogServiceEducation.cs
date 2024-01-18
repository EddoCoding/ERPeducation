using ERPeducation.Models.AdmissionCampaign.EducationDocuments;
using System.Windows.Controls;

namespace ERPeducation.Common.Interface.DialogEducation
{
    public interface IDialogServiceEducation
    {
        public UserControl GetUserControl(TypeEducationBaseModel selectedItem);
    }
}
