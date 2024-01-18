using ERPeducation.Models.AdmissionCampaign.EducationDocuments;

namespace ERPeducation.Common.Interface.DialogModel
{
    public interface IEducationModelService
    {
        TypeEducationBaseModel GetModel(object viewModel);
    }
}