using ERPeducation.Common.Interface.DialogModel;
using ERPeducation.Models.AdmissionCampaign.EducationDocuments;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel;

namespace ERPeducation.Common.Services.ServiceForEducation
{
    public class GetCertificateService : IEducationModelService
    {
        public TypeEducationBaseModel GetModel(object viewModel)
        {
            var certificateData = (CertificateViewModel)viewModel;

            string typeDocument = string.Empty;
            if (certificateData.TypeEducation == "Аттестат об Основном общем образовании") typeDocument = "Основное общее";
            else typeDocument = "Среднее общее";

            CertificateModel certificate = new CertificateModel()
            {
                TypeEducation = typeDocument,
                TypeEducationDocument = certificateData.TypeEducationDocument,
                IsBool = certificateData.IsBool,
                NumberCertificate = certificateData.NumberCertificate,
                DateOfIssue = certificateData.DateOfIssue,
                IsPopup = certificateData.IsPopup,
                IssuedBy = certificateData.IssuedBy
            };

            return certificate;
        }
    }
}
