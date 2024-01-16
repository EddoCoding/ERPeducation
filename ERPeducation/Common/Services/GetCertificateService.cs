using ERPeducation.Common.Interface;
using ERPeducation.Models.AdmissionCampaign.Documents;
using ERPeducation.Models.AdmissionCampaign.EducationDocuments;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel;

namespace ERPeducation.Common.Services
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
