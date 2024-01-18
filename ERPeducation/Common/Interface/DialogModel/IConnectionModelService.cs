using ERPeducation.Models.AdmissionCampaign.Documents;

namespace ERPeducation.Common.Interface.DialogModel
{
    public interface IConnectionModelService
    {
        DocsBase GetModel(object viewModelData);
    }
}