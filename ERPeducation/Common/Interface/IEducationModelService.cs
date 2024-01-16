using ERPeducation.Models.AdmissionCampaign.EducationDocuments;

namespace ERPeducation.Common.Interface
{
    public interface IEducationModelService
    {
        TypeEducationBaseModel GetModel(object viewModel);
    }
}
