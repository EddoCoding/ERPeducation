using ERPeducation.Common.Interface;
using ERPeducation.Models.AdmissionCampaign.Documents;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel;

namespace ERPeducation.Common.Services
{
    public class GetSnilsService : IConnectionModelService
    {
        public DocsBase GetModelDocument(object viewModelData)
        {
            var snilsData = (SnilsViewModel)viewModelData;

            Snils snils = new Snils()
            {
                TypeDocument = "СНИЛС",

                Number = snilsData.Number,
                RegistrationDate = snilsData.RegistrationDate
            };

            return snils;
        }
    }
}
