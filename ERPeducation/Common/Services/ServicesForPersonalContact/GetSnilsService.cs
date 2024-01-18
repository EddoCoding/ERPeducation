using ERPeducation.Common.Interface.DialogModel;
using ERPeducation.Models.AdmissionCampaign.Documents;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel;

namespace ERPeducation.Common.Services.ServicesForPersonalContact
{
    public class GetSnilsService : IConnectionModelService
    {
        public DocsBase GetModel(object viewModelData)
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
