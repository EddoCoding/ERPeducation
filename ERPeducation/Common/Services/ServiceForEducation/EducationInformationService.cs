using ERPeducation.Common.Interface.DialogEducation;
using ERPeducation.Models.AdmissionCampaign.EducationDocuments;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel;
using ERPeducation.Views.AdmissionCampaign.TabsView.TabEducation.InformationView;
using System.Windows.Controls;

namespace ERPeducation.Common.Services.ServiceForEducation
{
    public class EducationInformationService : IDialogServiceEducation
    {
        public UserControl GetUserControl(TypeEducationBaseModel selectedItem)
        {
            if (selectedItem is CertificateModel certificateModel)
            {
                CertificateInformationView view = new();
                view.DataContext = new CertificateViewModel(null, null, null, null)
                {
                    TypeEducation = certificateModel.TypeEducation,
                    TypeEducationDocument = certificateModel.TypeEducationDocument,
                    IsBool = certificateModel.IsBool,
                    NumberCertificate = certificateModel.NumberCertificate,
                    DateOfIssue = certificateModel.DateOfIssue,
                    IssuedBy = certificateModel.IssuedBy
                };

                return view;
            }
            if (selectedItem is DiplomaModel diplomaModel)
            {
                DiplomaInforamtionView view = new();
                view.DataContext = new DiplomaViewModel(null, null, null, null)
                {
                    TypeEducation = diplomaModel.TypeEducation,
                    TypeEducationDocument = diplomaModel.TypeEducationDocument,
                    IsBool = diplomaModel.IsBool,
                    DateOfIssue = diplomaModel.DateOfIssue,
                    IssuedBy = diplomaModel.IssuedBy,
                    NumberDiploma = diplomaModel.NumberDiploma,
                    RegistrationNumber = diplomaModel.RegistrationNumber,
                    Qualification = diplomaModel.Qualification,
                    AdditionalNumberDiploma = diplomaModel.AdditionalNumberDiploma
                };

                return view;
            }

            return null;
        }
    }
}
