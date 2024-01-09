using ERPeducation.Models.AdmissionCampaign.Documents;

namespace ERPeducation.Common.Interface
{
    public interface IConnectionModelService
    {
        DocsBase GetModelDocument(object viewModelData);
    }
}