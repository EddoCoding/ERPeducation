using ERPeducation.Common.Interface;
using ERPeducation.Models.AdmissionCampaign.Documents;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel;

namespace ERPeducation.Common.Services
{
    public class GetInnService : IConnectionModelService
    {
        public DocsBase GetModelDocument(object viewModelData)
        {
            var innData = (InnViewModel)viewModelData;

            INN inn = new INN()
            {
                DateOfAssignment = innData.DateOfAssignment,
                NumberINN = innData.NumberINN,
                Organization = innData.Organization,
                SeriesNumber = innData.SeriesNumber
            };

            return inn;
        }
    }
}
