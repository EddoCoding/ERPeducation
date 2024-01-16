using ERPeducation.Models.AdmissionCampaign.Documents;

namespace ERPeducation.Common.Interface
{
    public interface IConnectionModelService
    {
        DocsBase GetModel(object viewModelData);
    }
}